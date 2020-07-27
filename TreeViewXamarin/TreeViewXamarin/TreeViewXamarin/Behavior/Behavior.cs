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
        #endregion

        #region Overrides

        protected override void OnAttachedTo(ContentPage bindable)
        {
            TreeView = bindable.FindByName<SfTreeView>("treeView");
            TreeView.Loaded += TreeView_Loaded;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            TreeView.Loaded -= TreeView_Loaded;
            TreeView = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Methods
        private void TreeView_Loaded(object sender, TreeViewLoadedEventArgs e)
        {
            var viewModel = (sender as SfTreeView).BindingContext as FileManagerViewModel;
            var item = viewModel.ImageNodeInfo[3].SubFiles[1];

            if (item != null)
            {
                if (ExpandToSelection(TreeView, TreeView.Nodes, item))
                {
                    TreeView.BringIntoView(item, true);
                    TreeView.SelectedItem = item;
                }
            }
        }

        private bool ExpandToSelection(SfTreeView tree, TreeViewNodeCollection nodes, object model)
        {
            foreach (var node in nodes)
            {
                if ((node.Content as FileManager).ItemName == (model as FileManager).ItemName)
                {
                    var parent = node.ParentNode;
                    while (parent != null)
                    {
                        tree.ExpandNode(parent);
                        parent = parent.ParentNode;
                    }
                    return true;
                }
            }
            foreach (var node in nodes)
            {
                if (node.HasChildNodes)
                {
                    var found = ExpandToSelection(tree, node.ChildNodes, model);
                    if (found)
                        return true;
                }
            }
            return false;
        }
        #endregion
    }
}
