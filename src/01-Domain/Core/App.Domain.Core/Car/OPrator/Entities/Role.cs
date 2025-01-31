

using App.Domain.Core.Car.OPrator.Entities;

public class Role
{
    #region Properties
    public int Id { get; set; }
    public string Title { get; set; }
    #endregion

    #region NavigationProperties
    public List<OperatorCar> OperatorCars { get; set; }
    #endregion
}