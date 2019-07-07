function User(fullName)
{
    this.fullName = fullName;
    Object.defineProperties(this, { firstName: { get: function () { return this.fullName.split(" ")[0]; }, set: function (value) { this.fullName = value + " " + this.lastName; } }, lastName: { get: function () { return this.fullName.split(" ")[1]; }, set: function (value) { this.fullName = this.firstName + " " + value; } } });
}

var user = new User("Василий Петров");
alert(user.firstName);
alert(user.lastName);
user.firstName = "Пётр";
user.lastName = "Иванов";
alert(user.fullName);