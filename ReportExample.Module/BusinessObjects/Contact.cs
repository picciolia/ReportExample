using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;

namespace ReportExample.Module.BusinessObjects
{
    [NavigationItem("Marketing")]
    [VisibleInReports]
    public class Contact : BaseObject
    {
        public virtual String FirstName { get; set; }

        public virtual String LastName { get; set; }

        // Use this attribute to specify the maximum number of characters that the property's editor can contain.
        [FieldSize(255)]
        public virtual String Email { get; set; }
    }
}
