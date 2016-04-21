using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;
*/
//using PetaPoco;

namespace ArchLib
{
    /*
    public class TransactionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Database db = invocation.Request.Kernel.Get<Database>();
            using (var scope = db.GetTransaction())
            {
                // Do transacted updates here
                invocation.Proceed();
                // Commit
                scope.Complete();
            }
        }
    }

    public class TransactionAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return new TransactionInterceptor();
        }
    }
     */
}
