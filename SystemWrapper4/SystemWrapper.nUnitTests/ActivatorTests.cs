using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SystemInterface;
using NUnit.Framework;
using Moq;

namespace SystemWrapper.nUnitTests
{
    public class DummyClass
    {
        public string StringProperty { get; private set; }

        public DummyClass(string stringPropertyValue)
        {
            StringProperty = stringPropertyValue;
        }
    }

    [TestFixture]
    public class when_creating_a_new_instance_via_ActivatorWrapper
    {
        [Test]
        public void _01_SHOULD_return_a_DummyClass_instance()
        {
            string stringPropertyValue = "Sat Sri Akal!";
            ActivatorWrapper wrapper = new ActivatorWrapper();
            DummyClass expectedDummy;

            expectedDummy = wrapper.CreateInstance(typeof(DummyClass), new object[] { stringPropertyValue }) as DummyClass;

            Assert.That(expectedDummy.StringProperty, Is.EqualTo(stringPropertyValue));
        }
    }

    [TestFixture]
    public class when_mocking_IActivator
    {
        [Test]
        public void _01_SHOULD_be_able_to_mock_IActivator_functions()
        {
            string messageContents = "Sat Sri Akal!";
            Mock<IActivator> activator = new Mock<IActivator>(MockBehavior.Strict);
            activator.Setup(act => act.CreateInstance(typeof(DummyClass), null)).Returns(new DummyClass(messageContents));

            DummyClass resultFromMockCall = activator.Object.CreateInstance(typeof(DummyClass), null) as DummyClass;

            Assert.That(resultFromMockCall.StringProperty, Is.EqualTo(messageContents));
        }
    }
}
