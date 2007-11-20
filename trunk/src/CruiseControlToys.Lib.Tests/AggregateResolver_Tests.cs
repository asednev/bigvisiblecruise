using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Rhino.Mocks;

namespace CruiseControlToys.Lib.Tests
{

    [TestFixture]
    public class AggregateResolver_Tests
    {

        [Test]
        public void aggregate_resolver_resolves_when_there_is_only_one_contained_resolver() 
        {
            MockRepository mockRepository = new MockRepository();
            IResolver oneResolver = mockRepository.CreateMock<IResolver>();
            Expect.Call(oneResolver.GetProjects()).Return(null);
            mockRepository.ReplayAll();

            List<IResolver> resolvers = new List<IResolver>();
            resolvers.Add(oneResolver);

            IResolver aggregateResolver = new AggregateResolver(resolvers);
            aggregateResolver.GetProjects();

            mockRepository.VerifyAll();
        }

        [Test]
        public void aggregate_resolver_resolves_when_there_are_multipile_resolvers()
        {

            MockRepository mockRepository = new MockRepository();
            
            IResolver oneResolver = mockRepository.CreateMock<IResolver>();
            Expect.Call(oneResolver.GetProjects()).Return(null);
            IResolver twoResolver = mockRepository.CreateMock<IResolver>();
            Expect.Call(twoResolver.GetProjects()).Return(null);
            mockRepository.ReplayAll();

            List<IResolver> resolvers = new List<IResolver>();
            resolvers.Add(oneResolver);
            resolvers.Add(twoResolver);

            IResolver aggregateResolver = new AggregateResolver(resolvers);
            aggregateResolver.GetProjects();

            mockRepository.VerifyAll();
        }

        [Test]
        public void aggregate_resolver_can_aggregate_multiple_resolvers() 
        {
            MockRepository mockRepository = new MockRepository();

            ObservableCollection<ProjectStatus> oneProjectStatusCollection = new ObservableCollection<ProjectStatus>();
            oneProjectStatusCollection.Add(new ProjectStatus());

            ObservableCollection<ProjectStatus> twoProjectStatusCollection = new ObservableCollection<ProjectStatus>();
            twoProjectStatusCollection.Add(new ProjectStatus());

            IResolver oneResolver = mockRepository.CreateMock<IResolver>();
            Expect.Call(oneResolver.GetProjects()).Return(oneProjectStatusCollection);
            IResolver twoResolver = mockRepository.CreateMock<IResolver>();
            Expect.Call(twoResolver.GetProjects()).Return(twoProjectStatusCollection);
            mockRepository.ReplayAll();

            List<IResolver> resolvers = new List<IResolver>();
            resolvers.Add(oneResolver);
            resolvers.Add(twoResolver);

            IResolver aggregateResolver = new AggregateResolver(resolvers);
            Assert.That(aggregateResolver.GetProjects().Count, Is.EqualTo(2));

            mockRepository.VerifyAll();
        }

    }


}
