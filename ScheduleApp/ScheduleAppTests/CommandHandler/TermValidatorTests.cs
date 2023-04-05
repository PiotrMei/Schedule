using ScheduleApp.Entities;
using Xunit;
using FluentAssertions;

namespace ScheduleApp.CommandHandler.Tests
{
    public class TermValidatorTests
    {
        //public static IEnumerable<object[]> GetInvalidTestData()
        //{
        //    yield return new object[]
        //        {
        //        new Appointment()
        //            {
        //            AppointmentStart = new DateTime(2022, 04, 04, 12, 00, 00),
        //            AppointmentEnd = new DateTime(2022, 04, 04, 15, 00, 00)
        //        }
        //        };
        //    yield return new object[]
        //        {
        //        new Appointment()
        //            {
        //            AppointmentStart = new DateTime(2022, 04, 04, 12, 00, 00),
        //            AppointmentEnd = new DateTime(2022, 04, 04, 14, 00, 00)
        //        }
        //        };
        //    yield return new object[]
        //        {
        //        new Appointment()
        //            {
        //            AppointmentStart = new DateTime(2022, 04, 04, 14, 00, 00),
        //            AppointmentEnd = new DateTime(2022, 04, 04, 17, 00, 00)
        //        }
        //        };
        //    yield return new object[]
        //        {
        //        new Appointment()
        //            {
        //            AppointmentStart = new DateTime(2022, 04, 04, 15, 00, 00),
        //            AppointmentEnd = new DateTime(2022, 04, 04, 17, 00, 00)
        //        }
        //        };
        //    yield return new object[]
        //        {
        //        new Appointment()
        //            {
        //            AppointmentStart = new DateTime(2022, 04, 03, 13, 00, 00),
        //            AppointmentEnd = new DateTime(2022, 04, 06, 18, 00, 00)
        //        }
        //        };
        //}

        //[Theory]
        //[MemberData(nameof(GetInvalidTestData))]
        //public void ValidateTest_ForInvalidData_ForbiddenException(Appointment appointment)
        //{
        //    //arrange
        //    List<Appointment> appointments = new List<Appointment>()
        //    { new Appointment(){
        //    AppointmentStart = new DateTime(2022, 04, 04, 14, 00, 00),
        //    AppointmentEnd = new DateTime(2022, 04, 04, 15, 00, 00)}};
        //    //act
        //    var result = TermValidator.Validate(appointment, appointments);
        //    //assert
        //    result.Should().BeFalse();

        //}

        //public static IEnumerable<object[]> GetValidTestData()
        //{
        //    yield return new object[]
        //        {
        //        new Appointment()
        //            {
        //            AppointmentStart = new DateTime(2022, 04, 04, 12, 00, 00),
        //            AppointmentEnd = new DateTime(2022, 04, 04, 13, 00, 00)
        //        }
        //        };
        //    yield return new object[]
        //        {
        //        new Appointment()
        //            {
        //            AppointmentStart = new DateTime(2022, 04, 04, 15, 01, 00),
        //            AppointmentEnd = new DateTime(2022, 04, 04, 16, 00, 00)
        //        }
        //        };
        //}

        //[Theory]
        //[MemberData(nameof(GetValidTestData))]
        //public void ValidateTest_ForValidData_ForbiddenException(Appointment appointment)
        //{
        //    //arrange
        //    List<Appointment> appointments = new List<Appointment>()
        //    { new Appointment(){
        //    AppointmentStart = new DateTime(2022, 04, 04, 14, 00, 00),
        //    AppointmentEnd = new DateTime(2022, 04, 04, 15, 00, 00)},
        //    new Appointment(){
        //    AppointmentStart = new DateTime(2022, 04, 03, 14, 00, 00),
        //    AppointmentEnd = new DateTime(2022, 04, 03, 15, 00, 00)},
        //    new Appointment(){
        //    AppointmentStart = new DateTime(2022, 04, 05, 14, 00, 00),
        //    AppointmentEnd = new DateTime(2022, 04, 05, 15, 00, 00)}
        //    };
        //    //act
        //    var result = TermValidator.Validate(appointment, appointments);
        //    //assert
        //    result.Should().BeTrue();

        //}
    }
}