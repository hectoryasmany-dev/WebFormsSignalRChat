//using DevExpress.ExpressApp.Editors;
//using DevExpress.ExpressApp.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.UI.HtmlControls;

//namespace WebFormsSignalRChat.Module.Web.Editors
//{
//    public interface IModelIFrameViewItem : IModelViewItem { }
//    [ViewItem(typeof(IModelIFrameViewItem))]
//    public class SignalRCHat : ViewItem
//    {
//        public SignalRCHat(IModelIFrameViewItem model, Type classType) : base(classType, model.Id) { }
//        protected override object CreateControlCore()
//        {
//            HtmlGenericControl frame = new HtmlGenericControl("iframe");
//            frame.Attributes["src"] = "../Index.html";
//            frame.Attributes["width"] = "100%";
//            frame.Attributes["height"] = "500px";
//            return frame;
//        }
//    }
//}
