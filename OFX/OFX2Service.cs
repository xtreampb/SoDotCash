﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using OFX.Types;

namespace OFX
{
    /// <summary>
    /// Provides an interface to an online OFX service using the OFX2 protocol
    /// </summary>
    public class OFX2Service
    {
        public OFX2Service(OFXFinancialInstitution financialInstitution, OFXCredentials userCredentials)
        {
            this.financialInstitution = financialInstitution;
            this.userCredentials = userCredentials;

            // Setup default MessageSetData  - used in requests that do not have more specific data
            defaultMessageSetProfile = new DefaultMessageSetRequestProfile(financialInstitution.ServiceEndpoint,
                "Realm1");
        }

        /// <summary>
        /// Retrieve a statement for a single account. Includes transaction details.
        /// </summary>
        /// <param name="account">The account to retrieve statement data for</param>
        /// <param name="startDate">Start of date range for transactions</param>
        /// <param name="endDate">End of date range for transactions</param>
        /// <returns>List of statements containing the requested data.</returns>
        public async Task<IEnumerable<Types.Statement>> GetStatement(Types.Account account, DateTimeOffset startDate,
            DateTimeOffset endDate)
        {
            if (account is Types.BankAccount)
                return await GetStatement((Types.BankAccount)account, startDate, endDate);
            else
                return await GetStatement((Types.CreditCardAccount)account, startDate, endDate);
        }

        /// <summary>
        /// Retrieve a statement for a single bank account. Includes transaction details.
        /// </summary>
        /// <param name="account">The bank account to retrieve statement data for</param>
        /// <param name="startDate">Start of date range for transactions</param>
        /// <param name="endDate">End of date range for transactions</param>
        /// <returns>List of statements containing the requested data.</returns>
        public async Task<IEnumerable<Types.Statement>> GetStatement(Types.BankAccount account, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            // Ensure service catalog is populated
            await PopulateServiceProfiles();

            // Retrieve request profile for this message set
            var requestProfile = GetMessageSetRequestProfile(typeof(BankMessageSetV1));

            // Form specification of the account to retrieve information for
            var bankAccount = getOFXBankAccount(account);

            // Form transaction inclusion specification for date range. Always include transaction details
            var transactionInclusion = new IncTransaction
            {
                DTSTART = OFXUtils.DateToOFX(startDate),
                DTEND = OFXUtils.DateToOFX(endDate),
                INCLUDE = BooleanType.Y
            };

            // Wrap in statement request
            var statementRequest = new StatementRequest
            {
                BANKACCTFROM = bankAccount,
                INCTRAN = transactionInclusion
            };

            // Wrap in transaction
            var transactionRequest = new StatementTransactionRequest
            {
                TRNUID = GetNextTransactionId(),
                STMTRQ = statementRequest
            };

            // Wrap in messageset
            var messageSet = new BankRequestMessageSetV1 {Items = new AbstractRequest[1] { transactionRequest } };

            // Gather all message sets in the request
            var requestMessageSets = new List<AbstractTopLevelMessageSet>
            {
                CreateSignonRequest(userCredentials, requestProfile),
                messageSet
            };

            // Send to service and await response
            OFX response = await new OFXTransport(requestProfile.ServiceEndpoint).sendRequestAsync(requestMessageSets.ToArray());

            // TODO: Check response for errors

            // Extract statement data and return
            return Types.Statement.CreateFromOFXResponse(response);
        }

        /// <summary>
        /// Retrieve a statement for a single credit card account. Includes transaction details.
        /// </summary>
        /// <param name="account">The credit card account to retrieve statement data for</param>
        /// <param name="startDate">Start of date range for transactions</param>
        /// <param name="endDate">End of date range for transactions</param>
        /// <returns>List of statements containing the requested data.</returns>
        public async Task<IEnumerable<Types.Statement>> GetStatement(Types.CreditCardAccount account, DateTimeOffset startDate, DateTimeOffset endDate)
        {
            // Ensure service catalog is populated
            await PopulateServiceProfiles();

            // Retrieve request profile for this message set
            var requestProfile = GetMessageSetRequestProfile(typeof(BankMessageSetV1));

            // Form specification of the account to retrieve information for
            var creditAccount = getOFXCreditAccount(account);

            // Form transaction inclusion specification for date range. Always include transaction details
            var transactionInclusion = new IncTransaction
            {
                DTSTART = OFXUtils.DateToOFX(startDate),
                DTEND = OFXUtils.DateToOFX(endDate),
                INCLUDE = BooleanType.Y
            };

            // Wrap in statement request
            var statementRequest = new CreditCardStatementRequest
            {
                CCACCTFROM = creditAccount,
                INCTRAN = transactionInclusion
            };

            // Wrap in transaction
            var transactionRequest = new CreditCardStatementTransactionRequest
            {
                TRNUID = GetNextTransactionId(),
                CCSTMTRQ = statementRequest
            };

            // Wrap in messageset
            var messageSet = new CreditcardRequestMessageSetV1 { Items = new AbstractTransactionRequest[1] { transactionRequest } };

            // Gather all message sets in the request
            var requestMessageSets = new List<AbstractTopLevelMessageSet>
            {
                CreateSignonRequest(userCredentials, requestProfile),
                messageSet
            };

            // Send to service and await response
            OFX response = await new OFXTransport(requestProfile.ServiceEndpoint).sendRequestAsync(requestMessageSets.ToArray());

            // TODO: Check response for errors

            // Extract statement data and return
            return Types.Statement.CreateFromOFXResponse(response);
        }

        /// <summary>
        /// Helper method which creates and fills in a BankAccount with information from the passed account info
        /// </summary>
        /// <param name="account">Populated Types.BankAccount with bank info</param>
        /// <returns>Populated OFX BankAccount</returns>
        protected BankAccount getOFXBankAccount(Types.BankAccount account)
        {
            var bankAccount = new BankAccount
            {
                BANKID = account.RoutingId,
                ACCTID = account.AccountId
            };
            if (account is Types.CheckingAccount)
                bankAccount.ACCTTYPE = AccountEnum.CHECKING;
            else
                bankAccount.ACCTTYPE = AccountEnum.SAVINGS;

            return bankAccount;
        }

        /// <summary>
        /// Helper method which creates and fills in a BankAccount with information from the passed account info
        /// </summary>
        /// <param name="account">Populated Types.BankAccount with bank info</param>
        /// <returns>Populated OFX BankAccount</returns>
        protected CreditCardAccount getOFXCreditAccount(Types.CreditCardAccount account)
        {
            var creditAccount = new CreditCardAccount
            {
                ACCTID = account.AccountId
            };

            return creditAccount;
        }

        /// <summary>
        /// List all accounts available from the service
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Types.Account>> ListAccounts()
        {
            // Ensure service catalog is populated
            await PopulateServiceProfiles();

            // Retrieve request profile for this message set
            var requestProfile = GetMessageSetRequestProfile(typeof(SignupMessageSetV1));

            // Populate the account info request
            var accountInfoRequest = new AccountInfoRequest {DTACCTUP = "19970101"};
            // Use an early date for "last update" so we always retrieve information

            // Wrap the request in a transaction
            var transaction = new AccountInfoTransactionRequest
            {
                TRNUID = GetNextTransactionId(),
                ACCTINFORQ = accountInfoRequest
            };

            var messageSet = new SignupRequestMessageSetV1 {Items = new AbstractRequest[1] {transaction}};

            // Gather all message sets in the request
            var requestMessageSets = new List<AbstractTopLevelMessageSet>
            {
                CreateSignonRequest(userCredentials, requestProfile),
                messageSet
            };

            // Send to service and await response
            OFX response = await new OFXTransport(requestProfile.ServiceEndpoint).sendRequestAsync(requestMessageSets.ToArray());

            // TODO: Check response for errors



            // Walk nested elements to find accounts
            List<Types.Account> accountList = new List<Account>();
            foreach (var responseMessageSet in response.Items.Where(item => item.GetType() == typeof(SignupResponseMessageSetV1)).Select(item => (SignupResponseMessageSetV1)item))
            {
                foreach (
                    var transactionResponse in
                        responseMessageSet.Items.Where(item => item.GetType() == typeof (AccountInfoTransactionResponse))
                            .Select(item => (AccountInfoTransactionResponse) item))
                {
                    // Iterate each account
                    foreach (var accountInfo in transactionResponse.ACCTINFORS.ACCTINFO)
                    {
                        var specificAccountInfo = accountInfo.Items[0];
                        // Create appropriate account type entry
                        if (specificAccountInfo.GetType() == typeof(BankAccountInfo))
                        {
                            // There are multiple types of bank accounts we support
                            var bankAccountInfo = (BankAccountInfo) specificAccountInfo;
                            accountList.Add(Types.Account.Create(bankAccountInfo.BANKACCTFROM));
                        }
                        if (specificAccountInfo.GetType() == typeof(CreditCardAccountInfo))
                        {
                            var creditAccountInfo = (CreditCardAccountInfo)specificAccountInfo;
                            accountList.Add(Types.Account.Create(creditAccountInfo.CCACCTFROM));
                        }
                    }
                }
            }

            return accountList;
        }

        /// <summary>
        /// List the profiles available from the service. This does not use the provided user credentials.
        /// This call is usually only needed internally, but is exposed publicly for completeness and debugging.
        /// Profiles are the mechanism through which an OFX service specifies supported operations and informs
        ///   the client of communication options.
        /// 
        /// This is an asyncronous call.
        /// </summary>
        /// <returns>The completed task returns an OFX wrapper containing the result of the call and, on success, a ProfileResponseMessageSetV1</returns>
        public async Task<OFX> ListProfiles()
        {
            // Populate the profile request
            var profileRequest = new ProfileRequest
            {
                CLIENTROUTING = ClientRoutingEnum.MSGSET,
                DTPROFUP = "19970101"
            };
            // We can support different endpoints for each message
            // Use an early date for "last update" so we always retrieve information

            // Wrap the request in a transaction
            var profileTransaction = new ProfileTransactionRequest
            {
                PROFRQ = profileRequest,
                TRNUID = GetNextTransactionId()
            };

            // Transactions are wrapped in the appropriate message set type
            var profileMessageSet = new ProfileRequestMessageSetV1
            {
                PROFTRNRQ = new ProfileTransactionRequest[1] {profileTransaction}
            };

            // Gather all message sets in the request
            var requestMessageSets = new List<AbstractTopLevelMessageSet>
            {
                CreateSignonRequest(new OFXCredentials("anonymous00000000000000000000000",
                    "anonymous00000000000000000000000")),
                profileMessageSet
            };

            // Send to service and await response
            return await new OFXTransport(financialInstitution.ServiceEndpoint).sendRequestAsync(requestMessageSets.ToArray());
        }

        /// <summary>
        /// Populates a signon request for this service using the provided user credentials.
        /// Some OFX calls can use special credentials different than a FI account holder, so this method
        ///   allows the caller to specify credentials
        /// </summary>
        /// <param name="credentials">Authentication credentials to use for this request. If no credentials are specified, the default user credentials for the service are used.</param>
        /// <param name="requestProfile">Request profile specifying communication parameters for this request</param>
        /// <returns></returns>
        protected SignonRequestMessageSetV1 CreateSignonRequest(OFXCredentials credentials=null, MessageSetRequestProfile requestProfile=null)
        {
            // If no credentials are specified, use the default user credentials assigned when the service was constructed
            if (credentials == null)
                credentials = userCredentials;
            // If no request profile is specified, use the default
            if (requestProfile == null)
                requestProfile = defaultMessageSetProfile;

            // Populate the FinancialInstitution data
            var fi = new FinancialInstitution
            {
                ORG = this.financialInstitution.OrganizationId,
                FID = this.financialInstitution.FinancialId
            };

            // Populate a signon request with the current date and provided user credentials
            var signonRequest = new SignonRequest
            {
                DTCLIENT = OFXUtils.DateToOFX(new DateTimeOffset(DateTime.Now)),
                ItemsElementName = new ItemsChoiceType[2] {ItemsChoiceType.USERID, ItemsChoiceType.USERPASS},
                Items = new string[2] {credentials.UserId, credentials.Password},
                FI = fi,
                LANGUAGE = LanguageEnum.ENG,
                APPID = appId,
                APPVER = appVer
            };

            // Wrap the signon request in a signon message set, per protocol
            var signonMessageSet = new SignonRequestMessageSetV1 {SONRQ = signonRequest};

            // Return the fully populated request
            return signonMessageSet;
        }

        /// <summary>
        /// Called internally to populate serviceProfileDictionary
        /// <param name="forceRepopulate">If set to true the service profile dictionary will be loaded from remote even if already populated</param>
        /// </summary>
        protected async Task PopulateServiceProfiles(bool forceRepopulate=false)
        {
            // If already populated and forceRepopulate is not set, nothing to do
            if (serviceProfileDictionary.Count > 0 && !forceRepopulate)
                return;

            // Retrieve profile data from remote service
            var profileData = await ListProfiles();

            // Clear service dictionary for re-population below
            serviceProfileDictionary.Clear();

            // Iterate response items
            foreach (var responseSet in profileData.Items)
            {
                if (responseSet.GetType() == typeof(ProfileResponseMessageSetV1))
                {
                    var profileResponseset = (ProfileResponseMessageSetV1) responseSet;
                    foreach (var msgSet in profileResponseset.PROFTRNRS[0].PROFRS.MSGSETLIST.Items)
                    {
                        foreach (var msgSetVersion in from AbstractMessageSetVersion msgSetVersion in msgSet.GetType()
                            .GetProperties()
                            .Where(pi => pi.PropertyType == typeof(AbstractMessageSetVersion))
                            .Select(pi => pi.GetValue(msgSet, null))
                                                      select msgSetVersion)
                        {
                            // Add to dictionary
                            serviceProfileDictionary.Add(msgSetVersion.GetType(), new AbstractMessageSetRequestProfile(msgSetVersion));
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Retrieve the MessageSetRequestProfile describing how to interface with the OFX server when working with the specified class type
        /// </summary>
        /// <param name="messageSetClassType">Type of message class to lookup properties for</param>
        /// <returns>Data describing how to interface with the OFX service</returns>
        protected MessageSetRequestProfile GetMessageSetRequestProfile(Type messageSetClassType)
        {
            try
            {
                // Lookup in service dictionary
                return serviceProfileDictionary[messageSetClassType];
            }
            catch (KeyNotFoundException)
            {
                // Return default base service endpoint
                return defaultMessageSetProfile;
            }

        }

        /// <summary>
        /// Helper method to retrieve a unique transaction ID for each transaction.
        /// This implementation simply creates a globally unique identifier (GUID) as the transaction id.
        /// </summary>
        /// <returns>Unique transaction Id in string form</returns>
        protected string GetNextTransactionId()
        {
            return Guid.NewGuid().ToString();
        }



        #region MyRegion
        /// <summary>
        /// The message set profile data used for requests if no other profile is specified from the remote.
        /// </summary>
        protected MessageSetRequestProfile defaultMessageSetProfile;

        /// <summary>
        /// Properties of the financial institution used for online communication
        /// </summary>
        protected OFXFinancialInstitution financialInstitution;

        /// <summary>
        /// Credentials used to authenticate with the OFX service provider
        /// </summary>
        protected OFXCredentials userCredentials;

        /// <summary>
        /// Application Id of the product making the call.
        /// Many OFX endpoints use this to handle response quirks. We match the MS Money v16.00 protocol.
        /// Note that this MUST be a value that is on the provider's list of known products.
        /// </summary>
        protected readonly string appId = "Money";

        /// <summary>
        /// Application Version of the product making the call.
        /// Many OFX endpoints use this to handle response quirks. We match the MS Money v16.00 protocol.
        /// Note that this MUST be a value that is on the provider's list of known products.
        /// </summary>
        protected readonly string appVer = "1600";

        /// <summary>
        /// Dictionary mapping MessageSet type to data about the message
        /// </summary>
        private readonly Dictionary<Type, MessageSetRequestProfile> serviceProfileDictionary = new Dictionary<Type, MessageSetRequestProfile>();

        #endregion

    }
}
