window.onload = function ()
{
    var head = { glasses: 1 };
    var table = { pen: 3 };
    var bed = { sheet: 1, pillow: 2 };
    var pocket = { money: 2000 };
    table.__proto__ = head;
    bed.__proto__ = table;
    pocket.__proto__ = bed;
    alert("В современных браузерах, с точки зрения производительности, нет разницы, брать свойство из объекта или прототипа!");
};