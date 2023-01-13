// <copyright file="ListItemMapTests.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.Tests
{
    using Library.DataAccess;
    using NHibernate;
    using NUnit.Framework;
    public class MapTests
    {
        protected ISession Session { get; private set; }

        [SetUp]
        public void Setup()
        {
            this.Session = ConfiguratorTests.BuildSessionForTest();
        }

        [TearDown]
        public void TearDown()
        {
            this.Session?.Dispose();
        }
    }
}
