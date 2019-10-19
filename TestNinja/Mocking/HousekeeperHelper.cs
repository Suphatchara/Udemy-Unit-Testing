using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class HousekeeperHelper
    {
        private static readonly UnitOfWork UnitOfWork = new UnitOfWork();

        public static bool SendStatementEmails(DateTime statementDate)
        {
            var housekeepers = UnitOfWork.Query<Housekeeper>();
            foreach (var housekeeper in housekeepers)
            {
                if (housekeeper.Email == null)
                    continue;

                var statementFilename = SaveStatement(housekeeper.Oid, housekeeper.FullName, statementDate);

                if (string.IsNullOrWhiteSpace(statementFilename))
                    continue;

                var emailAddress = housekeeper.Email;
                var emailBody = housekeeper.StatementEmailBody;

                try
                {
                    EmailFile(emailAddress, emailBody, statementFilename,
                        string.Format("Sandpiper Statement {0:yyyy-MM} {1}", statementDate, housekeeper.FullName));
                }
                catch (Exception e)
                {
                    
                        XtraMessageBox.Show(e.Message, string.Format("Email failure: {0}", emailAddress),
                            MessageBoxButtons.OK);
                    
                }

                return true;
            }

        }





    }
}
