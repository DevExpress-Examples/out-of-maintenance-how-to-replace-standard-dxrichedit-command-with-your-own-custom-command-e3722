using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.XtraRichEdit.Services;
using DevExpress.Xpf.RichEdit;

namespace CustomCommand
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            richEditControl1.ApplyTemplate();
            richEditControl1.Loaded += new RoutedEventHandler(richEditControl1_Loaded);
        }

        void richEditControl1_Loaded(object sender, RoutedEventArgs e)
        {
            ReplaceRichEditCommandFactoryService(richEditControl1);
        }


        void ReplaceRichEditCommandFactoryService(RichEditControl control)
        {
            IRichEditCommandFactoryService service = control.GetService<IRichEditCommandFactoryService>();
            if (service == null)
                return;
            control.ReplaceService<IRichEditCommandFactoryService>(new CustomRichEditCommandFactoryService(control, service));
        }

    }
}
