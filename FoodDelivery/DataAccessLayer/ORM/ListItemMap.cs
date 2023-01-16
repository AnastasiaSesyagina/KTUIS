// <copyright file="ListItemMap.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.ORM
{
    using Domain;
    using FluentNHibernate.Mapping;

    /// <summary>
    /// Класс отображения Записи блюда в заказе.
    /// </summary>
    internal class ListItemMap : ClassMap<ListItem>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ListItemMap"/>.
        /// </summary>
        public ListItemMap()
        {
            this.Table("ListItems");

            this.Id(x => x.Id);

            this.Map(x => x.Quantity)
                .Not
                .Nullable();

            this.References(x => x.Order);

            this.HasMany(x => x.Products);
        }
    }
}
