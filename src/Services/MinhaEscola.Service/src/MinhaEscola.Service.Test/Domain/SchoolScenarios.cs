using MinhaEscola.Service.Domain.Administractive.Component.Limits;
using MinhaEscola.Service.Domain.Base.EnumTypes;
using MinhaEscola.Service.Domain.Board.School.Limits;

namespace MinhaEscola.Service.Test.Domain;

public class SchoolScenarios
{
    [Fact]
    public void Create_constructor_school_success()
    {
        //Arrange
        var school = new School();
        //Act

        //Assert

        Assert.NotNull(school);
    }

    [Fact]
    public void Append_component_with_success() {
        //Arrange
        var component = new Component();
        
        component.Id = 1;

        var school = new School();
        
        school.ActiveSchool();

        //Act
        school.AssignComponent(component);

        //Assert
        Assert.Equal(1, school.SchoolComponents.Count);
    }

    [Fact]
    public void Remove_component_with_error() {
        //Arrange
        var component = new Component();
        component.Id = 1;
        component.TypeOrganization = TypeOrganization.School;
        
        var school = new School();
        
        school.TypeOrganization = TypeOrganization.School;

        school.ActiveSchool();
        school.AssignComponent(component);

        //Act

        //Assert
        Assert.Throws<InvalidOperationException>(() => school.RemoveComponent(1));
    }

    [Fact]
    public void Remove_component_with_success() {
        //Arrange
        var component = new Component();
        component.Id = 1;

        var school = new School();

        school.ActiveSchool();
        school.AssignComponent(component);
        
        //Act
        
        school.RemoveComponent(0);

        //Assert
        Assert.Equal(0, school.SchoolComponents.Count);
    }
}
