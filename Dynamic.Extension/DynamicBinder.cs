using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Dynamic.Extension
{
    public class DynamicBinder
        : DynamicObject, IDynamicBinderProvider
    {
        private readonly IDictionary<string, object> dynamicMembers;


        public DynamicBinder()
        {
            this.dynamicMembers = new Dictionary<string, object>();
        }

        
        public object this[string propertyName]
        {
            get
            {
                if (this.dynamicMembers.ContainsKey(propertyName))
                    return this.dynamicMembers[propertyName];

                return null;
            }
            set
            {
                if (this.dynamicMembers.ContainsKey(propertyName))
                    this.dynamicMembers[propertyName] = value;

                this.dynamicMembers.Add(propertyName, value);
            }
        }


        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (this.dynamicMembers.ContainsKey(binder.Name))
            {
                result = this.dynamicMembers[binder.Name];
                return true;
            }

            return base.TryGetMember(binder, out result);
        }


        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (this.dynamicMembers.ContainsKey(binder.Name))
                this.dynamicMembers[binder.Name] = value;

            this.dynamicMembers.Add(binder.Name, value);

            return true;
        }


        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            string binderName = binder.Name;
            if (this.dynamicMembers.ContainsKey(binderName))
            {
                var del = this.dynamicMembers[binderName] as Delegate;
                if (del != null)
                {
                    result = del.DynamicInvoke(args);
                    return true;
                }
            }

            return base.TryInvokeMember(binder, args, out result);
        }


        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            if (this.dynamicMembers.ContainsKey(binder.Name))
            {
                this.dynamicMembers.Remove(binder.Name);
                return true;
            }

            return base.TryDeleteMember(binder);
        }


        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return this.dynamicMembers.Keys.ToArray();
        }
    }
}
