���� ������ "��������" ladder:

var ladder = 
{
	step: 0,
  	up: function()
	{
		this.step++;
	},
	down: function()
	{
		this.step--;
	},
	showStep: function()
	{
		alert(this.step);
	}
};

������, ���� ����� ��������������� ������� ��������� ������� �������, ��� ����� ������� ���:

ladder.up();
ladder.up();
ladder.down();
ladder.showStep();

�������������� ��� ������� �������, ����� ������ ����� ���� ������ ��������, ��� ���:

ladder.up().up().down().up().down().showStep();