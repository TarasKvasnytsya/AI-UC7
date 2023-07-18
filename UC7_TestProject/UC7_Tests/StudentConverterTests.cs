using System.Diagnostics;
using UC7_Logic;

namespace UC7_Tests
{
	public class StudentConverterTests
	{
		private readonly StudentConverter _converter;

		public StudentConverterTests()
		{
			_converter = new StudentConverter();
		}

		[Fact]
		public void ConvertStudents_OneStudent_ReturnHonorTrue()
		{
			//Arrange
			var studentList = GenerateStudentList(21, 91);

			//Act
			var result = _converter.ConvertStudents(studentList);

			//Assert
			Assert.Single(result);
			Assert.True(result.First().HonorRoll);
		}

		[Fact]
		public void ConvertStudents_OneStudent_ReturnExceptionalTrue()
		{
			//Arrange
			var studentList = GenerateStudentList(20, 91);

			//Act
			var result = _converter.ConvertStudents(studentList);

			//Assert
			Assert.Single(result);
			Assert.True(result.First().Exceptional);
		}

		[Fact]
		public void ConvertStudents_OneStudent_ReturnPassedTrue()
		{
			//Arrange
			var studentList = GenerateStudentList(20, 80);

			//Act
			var result = _converter.ConvertStudents(studentList);

			//Assert
			Assert.Single(result);
			Assert.True(result.First().Passed);
		}

		[Fact]
		public void ConvertStudents_OneStudent_ReturnPassedFalse()
		{
			//Arrange
			var studentList = GenerateStudentList(20, 70);

			//Act
			var result = _converter.ConvertStudents(studentList);

			//Assert
			Assert.Single(result);
			Assert.False(result.First().Passed);
		}

		[Fact]
		public void ConvertStudents_EmptyList_ReturnEmptyList()
		{
			//Arrange
			var studentList = new List<Student>();

			//Act
			var result = _converter.ConvertStudents(studentList);

			//Assert
			Assert.Empty(result);
		}

		[Fact]
		public void ConvertStudents_Null_ThrowError()
		{
			//Arrange
			List<Student>? studentList = null;

			//Act & Assert
			Assert.Throws<ArgumentNullException>(() => _converter.ConvertStudents(studentList));
		}

		private List<Student> GenerateStudentList(int age, int grade)
		{
			return new List<Student>
			{
				new Student
				{
					Age = age,
					Grade = grade
				}
			};
		}
	}
}