using Syncfusion.TreeView.Engine;
using Syncfusion.XForms.TreeView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields

        SfTreeView TreeView;
        Button Button;
        #endregion

        #region Overrides

        protected override void OnAttachedTo(ContentPage bindable)
        {
            TreeView = bindable.FindByName<SfTreeView>("treeView");
            Button = bindable.FindByName<Button>("button");
            Button.Clicked += Button_Clicked;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            Button.Clicked -= Button_Clicked;
            Button = null;
            TreeView = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Methods
        private void Button_Clicked(object sender, EventArgs e)
        {
            var viewModel = (sender as Button).BindingContext as FileManagerViewModel;
            var item = viewModel.ImageNodeInfo[3].SubFiles[1];
            TreeView.BringIntoView(item, true, true);
            TreeView.SelectedItem = item;
        }
        #endregion
    }
}