Дан код объекта User, который хранит имя и фамилию в свойстве this.fullName:

function User(fullName)
{
	this.fullName = fullName;
}

var user = new User("Василий Петров");

Имя и фамилия всегда разделяются пробелом.
Сделать так, чтобы были доступны свойства firstName и lastName, причём не только на чтение, но и на запись, вот так:

var user = new User("Василий Петров");
alert(user.firstName); // Василий
alert(user.lastName); // Петров
user.lastName = "Сидоров";
alert(user.fullName);

Важно: в этой задаче fullName должно остаться свойством, а firstName/lastName – реализованы через get/set. Лишнее дублирование здесь ни к чему.