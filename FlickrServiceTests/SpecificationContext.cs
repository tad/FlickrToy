using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrServiceTests
{
    public abstract class SpecificationContext
    {
        public virtual void Given()
        {
        }

        public virtual void When()
        {
        }

        [TestInitialize]
        public void Init()
        {
            Given();
            When();
        }
    }
}
