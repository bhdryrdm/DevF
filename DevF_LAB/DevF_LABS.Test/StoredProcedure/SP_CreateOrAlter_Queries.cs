using DevF_LABS.Test.DBConnection;
using System;

namespace DevF_LABS.Test.StoredProcedure
{
    public class SP_CreateOrAlter_Queries : RunQuery
    {
        private readonly string _connectionString;
        private readonly string _authorName;
        public SP_CreateOrAlter_Queries(string connectionString, string authorName)
        {
            _connectionString = connectionString;
            _authorName = authorName;
        }


        /// <summary>
        /// XSS Yorum sayısı 10'u geçtiği zaman silen Trigger
        /// </summary>
        public void DeleteInXSSComment_Trigger()
        {
            string triggerExistControlQuery = "IF OBJECT_ID('DeleteInXSSComment') IS NULL " +
                                                      "EXEC('CREATE TRIGGER DeleteInXSSComment AS') ";

            string sqlQuery = $"/****** Created By -> {this._authorName}   Script Date: { DateTime.Now } ******/ " +
                            "ALTER TRIGGER [dbo].[DeleteInXSSComment] ON  [dbo].[XSS_Comment] AFTER INSERT " +
                            "AS " +
                            "BEGIN " +
                                "IF (SELECT Count(ID) FROM XSS_Comment) > 10 " +
                                "Delete FROM XSS_Comment " +
                                "Where ID IN (SELECT TOP 1 ID FROM XSS_Comment) " +
                            "END";

            ConnectionDB(triggerExistControlQuery, this._connectionString);
            ConnectionDB(sqlQuery, this._connectionString);
        }

        /// <summary>
        /// XSS Cookie sayısı 50yi geçtiği zaman silen Trigger
        /// </summary>
        public void DeleteInXSSCookie_Trigger()
        {
            string triggerExistControlQuery = "IF OBJECT_ID('DeleteInXSSCookie') IS NULL " +
                                                     "EXEC('CREATE TRIGGER DeleteInXSSCookie AS') ";

            string sqlQuery = $"/****** Created By -> {this._authorName}   Script Date: { DateTime.Now } ******/ " +
                            "ALTER TRIGGER [dbo].[DeleteInXSSComment] ON  [dbo].[XSS_Cookie] AFTER INSERT " +
                            "AS " +
                            "BEGIN " +
                                "IF (SELECT Count(ID) FROM XSS_Cookie) > 50 " +
                                "Delete FROM XSS_Cookie " +
                                "Where ID IN (SELECT TOP 1 ID FROM XSS_Cookie) " +
                            "END";

            ConnectionDB(triggerExistControlQuery, this._connectionString);
            ConnectionDB(sqlQuery, this._connectionString);
        }

        /// <summary>
        /// XSS User sayısı 5i geçtiği zaman silen Trigger
        /// </summary>
        public void DeleteInXSSUser_Trigger()
        {
            string triggerExistControlQuery = "IF OBJECT_ID('DeleteInXSSUser') IS NULL " +
                                                     "EXEC('CREATE TRIGGER DeleteInXSSUser AS') ";

            string sqlQuery = $"/****** Created By -> {this._authorName}   Script Date: { DateTime.Now } ******/ " +
                            "ALTER TRIGGER [dbo].[DeleteInXSSUser] ON  [dbo].[XSS_User] AFTER INSERT " +
                            "AS " +
                            "BEGIN " +
                                "IF (SELECT Count(UserID) FROM XSS_User) > 5  " +
                                "Delete FROM XSS_User " +
                                "Where UserID IN ( " +
                                "SELECT TOP 1 UserID " +
                                "FROM ( " +
                                "SELECT UserID, ROW_NUMBER() " +
                                "OVER (ORDER BY(UserID)) " +
                                "AS ROW  FROM dbo.XSS_User " +
                                "   ) " +
                                "AS PAGED WHERE ROW > 2 " +
                                ") " +
                            "END";

            ConnectionDB(triggerExistControlQuery, this._connectionString);
            ConnectionDB(sqlQuery, this._connectionString);
        }
    }
}
