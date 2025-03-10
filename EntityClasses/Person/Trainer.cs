using EntityClasses.Abstractions;
using Throw;

namespace EntityClasses.Person;

public class Trainer: EntityClasses.Abstractions.Person
{
    private Guid _trainerTypeId;

    public Guid TrainerTypeId
    {
        get => _trainerTypeId;
        set => _trainerTypeId = value.Throw()
            .IfNull(ti => ti);
    }

    private DateOnly _experience;

    public DateOnly Experience
    {
        get => _experience;
        protected set => _experience = value.Throw().IfNull(e => e);
    }

    private string _description;

    public string Description
    {
        get => _description;
        protected set => _description = value.Throw()
            .IfNullOrWhiteSpace(d => d);
    }

    private float _price;

    public float Price
    {
        get => _price;
        protected set => _price = value.Throw()
            .IfNull(p => p)
            .IfNegative(p => p);
    }

    public TrainerType TrainerType { get; protected set; }

    public List<Specialization> Specializations { get; protected set; }

    public List<Reservation> Reservations { get; protected set; }

    private Trainer() { }

    protected Trainer(
        Guid trainerTypeId,
        string firstname,
        string lastname,
        DateOnly birthday,
        string phone,
        DateOnly experience,
        string description,
        float price)
        : base(firstname, lastname, birthday, phone)
    {
        TrainerTypeId = trainerTypeId;
        Experience = experience;
        Description = description;
        Price = price;
    }

    public static Trainer Create(
        Guid trainerTypeId,
        string firstname,
        string lastname,
        DateOnly birthday,
        string phone,
        DateOnly experience,
        string description,
        float price)
    {
        return new(
            trainerTypeId,
            firstname,
            lastname,
            birthday,
            phone,
            experience,
            description,
            price);
    }

    public void Update(
        Guid trainerTypeId,
        string firstname,
        string lastname,
        DateOnly birthday,
        string phone,
        DateOnly experience,
        string description,
        float price)
    {
        TrainerTypeId = trainerTypeId;
        FirstName = firstname; 
        LastName = lastname;
        Birthday = birthday;
        Phone = phone;
        Experience = experience;
        Description = description;
        Price = price;
    }
}
