using AppDemo.Views.FormData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Factory
{
    public enum typeForm {
        ADD,
        DELETE,
        UPDATE,
        READ
    };
    public class FormFactory
    {
        public BaseForm getForm(typeForm type, string cnnString, string tableName)
        {
            BaseForm res = null;
            switch (type)
            {
                case typeForm.ADD:
                    res = new AddForm(cnnString, tableName);
                    return res;
                case typeForm.READ:
                    res = new ReadForm(cnnString, tableName);
                    return res;
                case typeForm.UPDATE:
                    res = new UpdateForm(cnnString, tableName);
                    return res;
                case typeForm.DELETE:
                    res = new DeleteForm(cnnString, tableName);
                    return res;
                default:
                    return res;
            }
        }
    }
}
