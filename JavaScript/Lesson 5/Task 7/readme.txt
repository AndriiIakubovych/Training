��� ��� ������� User, ������� ������ ��� � ������� � �������� this.fullName:

function User(fullName)
{
	this.fullName = fullName;
}

var user = new User("������� ������");

��� � ������� ������ ����������� ��������.
������� ���, ����� ���� �������� �������� firstName � lastName, ������ �� ������ �� ������, �� � �� ������, ��� ���:

var user = new User("������� ������");
alert(user.firstName); // �������
alert(user.lastName); // ������
user.lastName = "�������";
alert(user.fullName);

�����: � ���� ������ fullName ������ �������� ���������, � firstName/lastName � ����������� ����� get/set. ������ ������������ ����� �� � ����.