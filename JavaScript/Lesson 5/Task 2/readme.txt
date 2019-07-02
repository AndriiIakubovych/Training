Есть объект "лестница" ladder:

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

Сейчас, если нужно последовательно вызвать несколько методов объекта, это можно сделать так:

ladder.up();
ladder.up();
ladder.down();
ladder.showStep();

Модифицировать код методов объекта, чтобы вызовы можно было делать цепочкой, вот так:

ladder.up().up().down().up().down().showStep();