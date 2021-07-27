namespace TodoApp.Dal.Entities.Interfaces
{
    public interface IEntity
    {
        /// <summary>
        /// Azért használok int-et és nem Guid-ot azonosítónak,
        /// mert az adatbázisnak segítünk így a fizikai tárolásban.
        /// (Egymás után tudja elhelyezni a rekordokat)
        /// </summary>
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
