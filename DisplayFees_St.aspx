<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayFees_St.aspx.cs" Inherits="St_Fees.DisplayFees_St" %>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="useCodeBehined.aspx.cs" Inherits="learnProject.useCodeBehined" %>--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
    <style type="text/css">
/*        .auto-style1 {height: 31px;}*/
        .pos_1 {height: 31px;margin-top:10px; margin-left:10px; } /*current year label*/
        .pos_2 {height: 31px;margin-top:10px; margin-left:50px; } /*current year text*/
        .pos_3 {height: 31px; margin-top:10px; margin-left:10px; } /*National ID label*/
        .pos_4 {height: 31px; margin-top:10px; margin-left:30px; } /*National ID text*/
        .pos_5 {height: 40px; margin-top:10px; margin-left:250px; width:120px} /*submit button*/
        .pos_6 {margin-top:10px; margin-left:250px; } /*st. ID label*/
        .pos_7 {height: 31px; margin-top:10px; margin-left:40px; width:60px } /*St. ID text*/
        .pos_8 {height: 31px; margin-top:10px; margin-left:250px; width:80px } /*Full Name label*/
        .pos_9 {height: 31px; margin-top:10px; margin-left:10px; width:500px } /*Full Name text*/
        .pos_10 {height: 31px; margin-top:10px; margin-left:250px; width:80px } /*YGP label*/
        .pos_11 {height: 31px; margin-top:10px; margin-left:4px; width:80px } /*YGP text*/
        .pos_12 {margin-top:10px; margin-left:250px} /*Grid*/
        .auto-style1 {
            width: 549px;
        }
    </style>
</head>
<body>
    <%--.classname { position: absolute;  top: 20px;  left: 50px;}--%>

    <form id="form1" runat="server">
        <div id="dvv1">
            <table id="tb1">
            <tr>
                <td class="auto-style1" >
                    <asp:Label  class="pos_1" Font-Names="Tahoma" font-size="16px" ID="Label1" runat="server" Text="Academic Year:"></asp:Label>
                    <asp:TextBox class="pos_2" Font-Names="Tahoma" font-size="16px"  ID="txtCY" runat="server" Height="24px" Width="149px">2023</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label class="pos_3" Font-Names="Tahoma" font-size="16px" ID="lbl1" runat="server" Text="Write National ID:"></asp:Label>
                    <asp:TextBox class="pos_4" Font-Names="Tahoma" font-size="16px" ID="txtNatID" runat="server" Height="24px" Width="147px" onkeypress="return isNumber(event)"></asp:TextBox>
                    <%--                    <asp:RegularExpressionValidator ID='vldNumber' ControlToValidate='txtNatID' Display='Dynamic' ErrorMessage='Not a number' ValidationExpression='(^([0-9]*|\d*\d{1}?\d*)$)' Runat='server'></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            </table>
        </div>
        <div id="dvv2">
            <table id="tb2">
            <tr>
                <td>
                    <asp:Button class="pos_5" Font-Names="Tahoma" ForeColor="Blue" font-size="20px" ID="CmdSubmit" runat="server" Text="Submit >>" OnClick="CmdSubmit_Click" />
                </td>
            </tr>
            </table>
        </div>
        <div id="dvv3">
            <table id="tb3">
            <tr>
                <td>
                    <asp:Label class="pos_6" Font-Names="Tahoma" font-size="16px" ID="lblID" runat="server" Text="St. ID:"></asp:Label>
                    <asp:TextBox class="pos_7" Font-Names="Tahoma" font-size="16px" ID="txtStID" runat="server" Height="24px" Width="147px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label class="pos_8" Font-Names="Tahoma" font-size="16px" ID="lblfullname" runat="server" Text="Full Name:"></asp:Label>
                    <asp:TextBox class="pos_9" Font-Names="Tahoma" font-size="16px" ID="txtFullName" runat="server" Height="24px" Width="147px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label class="pos_10" Font-Names="Tahoma" font-size="16px" ID="lblYgp" runat="server" Text="Year Group:"></asp:Label>
                    <asp:TextBox class="pos_11"  Font-Names="Tahoma" font-size="16px" ID="txtYGP" runat="server" Height="24px" Width="147px"></asp:TextBox>
                </td>
            </tr>
            </table>
        </div>
        <div id="dvv4">
            <table id="tb4">
            <tr>
                <td>
                    <%--OnRowDataBound="GvGetFees_DataBound" font-size="10px"--%>
                    <asp:GridView class="pos_12" ForeColor="black" Font-Names="Tahoma"  ID="GvGetFees" runat="server"  
                        AutoGenerateColumns="false" CellPadding="8" HeaderStyle-Font-Size="14px" HeaderStyle-BackColor="#2E3C59" HeaderStyle-ForeColor="White">
                    <columns>
<%--                    <asp:BoundField DataField="S_CODE" headertext="St. ID" ItemStyle-Width="0" />
                        <asp:BoundField DataField="FULLNAME" headertext="Student Name" ItemStyle-Width="0"/>
                        <asp:BoundField DataField="STAGENAME" headertext="Year Group" ItemStyle-Width="0"/>--%>
                        <asp:BoundField DataField="TERMNAME" headertext="Installment" ItemStyle-Width="90"/>
                        <asp:BoundField DataField="stdate" headertext="Due Date" ItemStyle-Width="90"/>
                        <asp:BoundField DataField="enddate" headertext="Deadline Date" ItemStyle-Width="90"/>
<%--                    <asp:BoundField DataField="SUBJECTNAME" headertext="Item Name" ItemStyle-Width="250"/>--%>
                        <asp:BoundField DataField="FEES" headertext="Total Fees" ItemStyle-Width="100"/>
                        <asp:BoundField DataField="TOTDISC" headertext="Total Disc." ItemStyle-Width="100"/>
                        <asp:BoundField DataField="TOTDUE" headertext="Total Due" ItemStyle-Width="100"/>
                        <asp:BoundField DataField="TOTPAID" headertext="Total Paid" ItemStyle-Width="100"/>
                        <asp:BoundField DataField="REM" headertext="Remaining" ItemStyle-Width="100"/>
                    </columns>
                    </asp:GridView>
                </td>
            </tr>
            </table>
        </div>
        <%--                    <asp:BoundField DataField="S_CODE" headertext="St. ID" ItemStyle-Width="0" />
                        <asp:BoundField DataField="FULLNAME" headertext="Student Name" ItemStyle-Width="0"/>
                        <asp:BoundField DataField="STAGENAME" headertext="Year Group" ItemStyle-Width="0"/>--%><%--                    <asp:BoundField DataField="SUBJECTNAME" headertext="Item Name" ItemStyle-Width="250"/>--%>
<script>
    function isNumber(evt) 
    {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
    }

</script>
    </form>
</body>
</html>
