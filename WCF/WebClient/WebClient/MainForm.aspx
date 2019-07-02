<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="WebClient.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="styles.css" rel="stylesheet" type="text/css"/>
        <title>Органайзер</title>
    </head>
    <body>
        <form id="Orgform" runat="server">
            <div class="main">
                <div class="content">
                    <asp:Calendar id="Calendar" CellPadding="0" CellSpacing="3" runat="server" OnSelectionChanged="Calendar_SelectionChanged">
                        <DayStyle ForeColor="#002d35"/>
                        <OtherMonthDayStyle ForeColor="Gray"/>
                        <SelectedDayStyle BackColor="#99ccff"/>
                        <TodayDayStyle ForeColor="#cc3300"/>
                    </asp:Calendar>
                    <asp:ListBox id="NotesList" AutoPostBack="true" runat="server" OnSelectedIndexChanged="NotesList_SelectedIndexChanged">
                    </asp:ListBox>
                    <div class="operations selected">
                        <asp:Button id="Add" Text="Добавить" runat="server" OnClick="Add_Click"/>
                        <asp:Button id="Edit" Text="Редактировать" runat="server" OnClick="Edit_Click"/>
                        <asp:Button id="Delete" Text="Удалить" runat="server" OnClick="Delete_Click"/>
                    </div>
                    <div class="info">
                        <asp:CheckBox id="Done" Text="Выполнено" runat="server" OnCheckedChanged="Done_CheckedChanged"/>
                        <asp:TextBox id="Description" ReadOnly="true" Rows="5" TextMode="MultiLine" runat="server"/>
                    </div>
                    <asp:Label id="DataErrorInfo" runat="server"/>
                </div>
                <asp:Panel id="AddWindow" runat="server">
                    <div class="overlay"></div>
                    <div class="dialog">
                        <div class="title"><span>Добавление заметки</span></div>
                        <asp:Label id="AddNoteNameText" Text="Введите название заметки:" runat="server"/>
                        <asp:TextBox id="AddNoteName" MaxLength="40" runat="server"/>
                        <asp:Label id="AddBeginningTimeText" Text="Введите время начала события:" runat="server"/>
                        <input id="AddBeginningTime" type="time" runat="server"/>
                        <asp:Label id="AddEndTimeText" Text="Введите время окончания события:" runat="server"/>
                        <input id="AddEndTime" type="time" runat="server"/>
                        <asp:Label id="AddDescriptionText" Text="Введите описание:" runat="server"/>
                        <asp:TextBox id="AddDescription" MaxLength="255" Rows="4" TextMode="MultiLine" runat="server"/>
                        <asp:Label id="AddError" Text="Некоторые значения введены неверно!" runat="server"/>
                        <asp:Button id="AddOk" Text="Подтвердить" runat="server" OnClick="AddOk_Click"/>
                        <asp:Button id="AddCancel" Text="Отмена" runat="server" OnClick="AddCancel_Click"/>
                    </div>
                </asp:Panel>
                <asp:Panel id="EditWindow" runat="server">
                    <div class="overlay"></div>
                    <div class="dialog">
                        <div class="title"><span>Редактирование заметки</span></div>
                        <asp:Label id="EditNoteNameText" Text="Название заметки:" runat="server"/>
                        <asp:TextBox id="EditNoteName" MaxLength="40" runat="server"/>
                        <asp:Label id="EditBeginningTimeText" Text="Время начала события:" runat="server"/>
                        <input id="EditBeginningTime" type="time" runat="server"/>
                        <asp:Label id="EditEndTimeText" Text="Время окончания события:" runat="server"/>
                        <input id="EditEndTime" type="time" runat="server"/>
                        <asp:Label id="EditDescriptionText" Text="Описание:" runat="server"/>
                        <asp:TextBox id="EditDescription" MaxLength="255" Rows="4" TextMode="MultiLine" runat="server"/>
                        <asp:Label id="EditError" Text="Некоторые значения введены неверно!" runat="server"/>
                        <asp:Button id="EditOk" Text="Подтвердить" runat="server" OnClick="EditOk_Click"/>
                        <asp:Button id="EditCancel" Text="Отмена" runat="server" OnClick="EditCancel_Click"/>
                    </div>
                </asp:Panel>
                <asp:Panel id="DeleteWindow" runat="server">
                    <div class="overlay"></div>
                    <div class="dialog">
                        <div class="title"><span>Удаление заметки</span></div>
                        <asp:Label id="DeleteText" Text="Вы действительно хотите удалить данную заметку?" runat="server"/>
                        <asp:Button id="DeleteYes" Text="Да" runat="server" OnClick="DeleteYes_Click"/>
                        <asp:Button id="DeleteNo" Text="Нет" runat="server" OnClick="DeleteNo_Click"/>
                    </div>
                </asp:Panel>
            </div>
        </form>
    </body>
</html>