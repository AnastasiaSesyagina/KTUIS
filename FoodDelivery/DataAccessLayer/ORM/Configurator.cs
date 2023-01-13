// <copyright file="Configurator.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.ORM
{
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Tool.hbm2ddl;

    /// <summary>
    /// FluentNHibernate конфигуратор.
    /// </summary>
    public static class Configurator
    {
        private static FluentConfiguration? fluentConfiguration;

        /// <summary>
        /// Создание фабрики сессий.
        /// </summary>
        /// <param name="settings"> Параметры СУБД. </param>
        /// <param name="assembly"> Целевая сборка. </param>
        /// <param name="showSql"> Показывать генерируемый SQL-код. </param>
        /// <returns> Фабрику сессий. </returns>
        public static ISessionFactory GetSessionFactory(
            Settings settings,
            Assembly? assembly = null,
            bool showSql = false)
        {
            return GetConfiguration(
                settings, assembly ?? Assembly.GetExecutingAssembly(), showSql)
                .BuildSessionFactory();
        }

        /// <summary>
        /// Создание конфигурации FluentNHibernate.
        /// </summary>
        /// <param name="settings"> Параметры СУБД. </param>
        /// <param name="assembly"> Целевая сборка. </param>
        /// <param name="showSql"> Отображение генерируемого SQL-код. </param>
        /// <returns> Конфигурация FluentNHibernate. </returns>
        private static FluentConfiguration GetConfiguration(
            Settings settings,
            Assembly assembly,
            bool showSql = false)
        {
            if (fluentConfiguration is null)
            {
                var databaseConfiguration =
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        x => x
                        .Server(settings.GetDatabaseServer())
                        .Database(settings.GetDatabaseName())
                        .TrustedConnection());

                if (showSql)
                {
                    databaseConfiguration = databaseConfiguration
                        .ShowSql()
                        .FormatSql();
                }

                fluentConfiguration = Fluently.Configure()
                    .Database(databaseConfiguration)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                    .ExposeConfiguration(BuildSchema);
            }

            return fluentConfiguration;
        }

        /// <summary>
        /// Создание схемы по конфигурации.
        /// </summary>
        /// <param name="configuration"> Конфигурация FluentNHibernate. </param>
        private static void BuildSchema(NHibernate.Cfg.Configuration configuration)
        {
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}
