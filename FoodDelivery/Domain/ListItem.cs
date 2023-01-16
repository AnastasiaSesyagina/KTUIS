// <copyright file="OrderProduct.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>


using System.ComponentModel;

namespace Domain
{
    /// <summary>
    /// Запись блюда в заказе.
    /// </summary>
    public class ListItem : IEquatable<ListItem>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ListItem"/>.
        /// </summary>
        /// <param name="quantity"> Количество. </param>
        /// <param name="order"> Заказ. </param>
        public ListItem(int quantity, Product product)
        {
           this.Id = Guid.NewGuid();
           this.Add(product, quantity);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ListItem"/>.
        /// Пустой конструктор для работы с ORM.
        /// </summary>
        [Obsolete("For ORM", true)]
        protected ListItem()
        {
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Количество позиций одного блюда.
        /// </summary>
        public virtual int Quantity { get; protected set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// Блюда.
        /// </summary>
        public virtual ISet<Product> Products { get; set; } = new HashSet<Product>();

        /// <inheritdoc/>
        public virtual bool Equals(ListItem? other)
        {
            return Equals(this.Id, other?.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="count"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public virtual void Add(Product product, int count)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            this.Quantity = count;
            this.Products.Add(product);
            product.ListItem = this;
        }
    }
}
