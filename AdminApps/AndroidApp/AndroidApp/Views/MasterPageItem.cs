using System;

namespace AndroidApp.Views
{
    public class MasterPageItem
    {
        public string Title { get;  set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
        public string Name { get; internal set; }
    }
}