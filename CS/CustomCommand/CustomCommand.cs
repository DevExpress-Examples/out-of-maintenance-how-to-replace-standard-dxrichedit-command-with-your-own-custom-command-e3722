using System.Windows;
using System.Windows.Controls;
using DevExpress.Utils;
using DevExpress.Xpf.RichEdit;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Services;

namespace CustomCommand
{
    #region customsavecommand
    public class CustomSaveDocumentCommand : SaveDocumentAsCommand
    {
        public CustomSaveDocumentCommand(IRichEditControl control)
            : base(control)
        {
        }

        protected override void ExecuteCore()
        {
            if (Control.Document.Paragraphs.Count > 7)
                base.ExecuteCore();
            else MessageBox.Show(@"You should type at least 7 paragraphs
  to be able to save the document.",
                "Please be creative", MessageBoxButton.OK);
        }
    }
    #endregion customsavecommand


    #region #iricheditcommandfactoryservice
    public class CustomRichEditCommandFactoryService : IRichEditCommandFactoryService
    {
        readonly IRichEditCommandFactoryService service;
        readonly RichEditControl control;

        public CustomRichEditCommandFactoryService(RichEditControl control,
            IRichEditCommandFactoryService service)
        {
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(service, "service");
            this.control = control;
            this.service = service;
        }

        #region IRichEditCommandFactoryService Members
        public RichEditCommand CreateCommand(RichEditCommandId id)
        {
            if (id == RichEditCommandId.FileSaveAs)
                return new CustomSaveDocumentCommand(control);

            return service.CreateCommand(id);
        }
        #endregion
    }
    #endregion #iricheditcommandfactoryservice


}
