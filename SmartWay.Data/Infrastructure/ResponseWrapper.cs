using System.Collections.Generic;
using System.Net;

namespace SmartWay.Data.Infrastructure
{
    public class ResponseWrapper<T> where T : class
    {
        public ResponseWrapper(List<T> lstitems, HttpStatusCode Status, string ErrorDetail, int IsError)
        {
            status = Status;

            statusDescription = ErrorDetail;

            if (lstitems != null)
            {
                records = lstitems;
                recordsCount = lstitems.Count;
            }
            else
            {
                records = null;
            }

            isError = isError;
        }

        public ResponseWrapper(List<T> lstitems, T obj, HttpStatusCode Status, string ErrorDetail, int IsError)
        {
            status = Status;

            statusDescription = ErrorDetail;

            if (lstitems != null)
            {
                records = lstitems;
                recordsCount = lstitems.Count;
            }

            else if (obj != null)
            {
                List<T> lstobjwrapper = new List<T>();
                lstobjwrapper.Add(obj);
                records = lstobjwrapper;
            }
            else
            {
                records = null;
            }

            isError = IsError;
        }

        public ResponseWrapper(List<T> lstitems, T obj, HttpStatusCode Status, string ErrorDetail, int IsError, int RecordCount)
        {
            status = Status;

            statusDescription = ErrorDetail;

            if (lstitems != null)
            {
                records = lstitems;
                recordsCount = RecordCount;
            }

            else if (obj != null)
            {
                List<T> lstobjwrapper = new List<T>();
                lstobjwrapper.Add(obj);
                records = lstobjwrapper;
            }
            else
            {
                records = null;
            }

            isError = IsError;
        }

        public ResponseWrapper(T Obj, HttpStatusCode Status, string ErrorDetail, int IsError, int RecordCount)
        {
            status = Status;
            statusDescription = ErrorDetail;
            if(Obj != null)
            {
                List<T> lstobjWrapper = new List<T>();
                lstobjWrapper.Add(Obj);
                records = lstobjWrapper;
            }
            else
            {
                records = null;
            }
            isError = IsError;
        }

        public HttpStatusCode status { get; set; }

        public string statusDescription { get; set; }

        public List<T> records { get; set; }

        public int isError { get; set; }

        public int recordsCount { get; set; }

    }
}
