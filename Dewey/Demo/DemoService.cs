using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class DemoService : IService
    {
        private void UpdateDefaults(ref Demo request)
        {
            if (!request.rowCount.HasValue) { request.rowCount = Demo.DEFAULT_ROW_COUNT; }
        }
        public object Any(Demo request)
        {
            DemoResponse response = new DemoResponse();
            ILog log = LogManager.GetLogger(GetType());
            log.Info("Dewey Demo Services");
            UpdateDefaults(ref request);
            if (request.Columns != null)
            {
                if (request.Columns.Length == 0)
                {
                    log.Fatal("Must specify Columns in order to receive a table of data.");
                    return null;
                }
                Random rand = new Random();
                response.Data = new List<List<object>>();
                IColumn DataColumn = new Name();
                for (int j = 0; j < request.rowCount; ++j)
                {
                    List<object> row = new List<object>();
                    for (int i = 0; i < request.Columns.Length; ++i)
                    {
                        if (request.Columns[i].max == null) { request.Columns[i].max = ColumnDescription.DEFAULT_MAX_NUMBER; }
                        if (request.Columns[i].min == null) { request.Columns[i].min = ColumnDescription.DEFAULT_MIN_NUMBER; }
                        switch (request.Columns[i].type.ToString())
                        {
                            case ColumnTypes.NUMBER_TYPE_NAME:
                                DataColumn = new Number(rand);
                                break;
                            case ColumnTypes.STRING_TYPE_NAME:
                                DataColumn = new Dewey.Demo.String();
                                break;
                            case ColumnTypes.NAME_TYPE_NAME:
                                DataColumn = new Name();
                                break;
                            case ColumnTypes.ADDRESS_TYPE_NAME:
                                DataColumn = new Address();
                                break;
                            case ColumnTypes.COMPANY_TYPE_NAME:
                                DataColumn = new Company();
                                break;
                            case ColumnTypes.INTERNET_TYPE_NAME:
                                DataColumn = new Internet();
                                break;
                            case ColumnTypes.PHONENUMBER_TYPE_NAME:
                                DataColumn = new PhoneNumber();
                                break;
                            case ColumnTypes.CHAR_TYPE_NAME:
                                DataColumn = new Dewey.Demo.Char(rand);
                                break;
                            case ColumnTypes.BOOL_TYPE_NAME:
                                DataColumn = new Dewey.Demo.Bool(rand);
                                break;
                            case ColumnTypes.DATE_TYPE_NAME:
                                DataColumn = new Dewey.Demo.Date(rand);
                                break;
                        }
                        row.Add(DataColumn.ColumnValue(request.Columns[i]));
                    }
                    response.Data.Add(row);
                }
            }
            return response;
        }
    }
}