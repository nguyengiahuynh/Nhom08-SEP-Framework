using SEP_framwork.Views.FormData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP_framwork.Factory
{
    public enum typeForm {
        ADD,
        DELETE,
        UPDATE,
        READ,
        HASFORMS
    };
    public class FormFactory
    {
        public BaseForm getForm(typeForm type, string cnnString, string tableName, BaseForm rootForm)
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
                case typeForm.HASFORMS:
                    res = new FormHasForms(cnnString, tableName, rootForm);
                    return res;
                default:
                    return res;
            }
        }
    }
}
