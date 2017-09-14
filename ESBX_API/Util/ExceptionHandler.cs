using System.Data.SqlClient;
using System.Net;
using System.Net.Http;

namespace ExpressSaladBarDesktop_API.Util
{
    public class ExceptionHandler
    {
        public static HttpResponseMessage CreatedHttpResponseException(string reason, HttpStatusCode code)
        {
            HttpResponseMessage msg = new HttpResponseMessage();

            msg.StatusCode = code;
            msg.Content = new StringContent(reason);
            msg.ReasonPhrase = reason;

            return msg;
        }

        public static string HandleException(SqlException error)
        {
            
            switch(error.Number)
            {
                case 2601: 
                    return GetUniqueExceptionMessage(error);
                default:
                    return error.Message + "(" + error.Number + ")";
            }
        }

        private static string GetUniqueExceptionMessage(SqlException error)
        {
            string newMessage = error.Message;

            int startIndex = newMessage.IndexOf("'");
            int endIndex = newMessage.IndexOf("'", startIndex + 1);

            int startIndexError = newMessage.IndexOf("'",endIndex+1);
            int endIndexError = newMessage.IndexOf("'", startIndexError + 1);

            if (startIndexError > 0 && endIndexError > 0)
            {
                string uniqeName = newMessage.Substring(startIndexError + 1, endIndexError - startIndexError - 1);

                if(uniqeName== "IX_Email")
                    newMessage="email_unique";
            }
            return newMessage;
        }
        
    }
}