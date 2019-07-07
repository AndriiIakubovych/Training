using System;
using System.Linq.Expressions;
using System.ComponentModel;

namespace GraphicFilesView
{
    public class FolderDialogViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression.Body.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = propertyExpression.Body as MemberExpression;
                string propertyName = memberExpression.Member.Name;
                OnPropertyChanged(propertyName);
            }
        }
    }
}