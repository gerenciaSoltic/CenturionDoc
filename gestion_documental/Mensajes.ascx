<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensajes.ascx.cs" Inherits="Web.Mensajes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>  

<script type="text/javascript" language="javascript">

    var Mensaje = '<%= mpext.ClientID %>';         

</script> 

<script language="JavaScript" type="text/JavaScript">

    function detectar_tecla() {
        with (event) {
            if (keyCode == 27) {
                $find(Mensaje).hide(); 
                return false;
            }
        }
    }
    document.onkeydown = detectar_tecla;
 </script>
 


<cc1:modalpopupextender
        BackgroundCssClass="modalBackground"
        PopupDragHandleControlID="Panel1"
        runat="server"
        PopupControlID="Panel1"
         CancelControlID="cerrarMSJ"
        id="mpext" 
        TargetControlID="popup" 
        />


 <asp:Label ID="popup" runat="server" Text="" ></asp:Label>  
 <asp:Panel ID="Panel1" runat="server" BackColor="Silver" BorderStyle="Outset">

  <div class="ui-dialog ui-widget ui-widget-content ui-corner-all ui-draggable ui-resizable" 
            style="left: 0px; top: 0px; width: 250px"  >
   <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix" 
          align="right" style="border-style: ridge" >
      <span id="Span1" class="ui-dialog-title" 
           style="font-style: normal; font-variant: normal; font-size: large; font-family: 'Bell MT';">&nbsp;Atención!</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="ui-dialog-titlebar-close ui-corner-all" href="#"><span ID="cerrarMSJ" 
           class="ui-icon ui-icon-closethick" 
           style="text-decoration: underline overline blink">| Cerrar | </span></a>&nbsp;&nbsp;&nbsp;
   </div>
   <div style="height: auto; min-height: 109px; width: auto;" class="ui-dialog-content ui-widget-content" id="Div1" align="left">
    

       <br />
       &nbsp; <asp:Label ID="lblMessage" runat="server" BorderColor="Black" ForeColor="Black"></asp:Label>
     <br />
     <div align="center">
     <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" Visible="False" 
           onclick="BtnAceptar_Click" />                 
    </div>
    </div>
    
   
     </div>  
 </asp:Panel>

 