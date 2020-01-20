<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="GIBS.Modules.GIBS_UMGslider.View" %>

<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude ID="DnnCssInclude1" runat="server" FilePath="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.css" />
<dnn:DnnCssInclude ID="DnnCssInclude2" runat="server" FilePath="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick-theme.min.css" />




<style type="text/css">

.img-thumbnail:hover {
    background-color: black;
    opacity: 0.5;
}

.yourclass {
    width: 90%;
    margin: 0 auto;
}

.slick-slide{
    margin-left:  5px;
    margin-right:  5px;
    height: 180px;
  }

    </style>

<asp:Label ID="LblDebug" runat="server" Visible="true" Text="" />

<asp:Repeater id="rptMedia" Runat="server">
	<HeaderTemplate>
  


<div class="slider yourclass">

      </HeaderTemplate>
	<ItemTemplate>
  
    <div style="background-color: #d3d3d3; text-align:center;"> 
        <a href='<%= _GalleryURL %>/AlbumId/<%# DataBinder.Eval(Container.DataItem, "AlbumID") %>/PhotoId/<%# DataBinder.Eval(Container.DataItem, "PhotoId") %>'>
       <img src='/Portals/0/UltraMediaGallery/<%= _ModuleID %>/<%# DataBinder.Eval(Container.DataItem, "AlbumID") %>/<%= _ContentType %><%# DataBinder.Eval(Container.DataItem, "Src") %>' alt='<%# DataBinder.Eval(Container.DataItem, "Title") %>' title='<%# DataBinder.Eval(Container.DataItem, "Title") %>' class="img-responsive" style="margin: 0 auto;" /></a></div>

    </ItemTemplate>
	<FooterTemplate>

</div></FooterTemplate>
	<SeparatorTemplate />
</asp:Repeater>


<script type="text/javascript">


    $(document).ready(function () {
     //  alert("hello world");

        //$('.yourclass').slick({
        //    slidesToShow: 3,
        //    dots: true,
        //    autoplay: true,
        //    speed: 300,
        //    infinite: true,
            
        //    slidesToScroll: 1
            
        //});

        $('.yourclass').slick({
            dots: true,
            infinite: true,
            speed: 300,
            slidesToShow: 5,
            slidesToScroll: 5,
            autoplay: true,
            centerMode: true,
            adaptiveHeight: true,
            
            
            centerMode: true,
            autoplaySpeed: 2000,
            responsive: [
                {
                    breakpoint: 1024,
                    settings: {
                        slidesToShow: 4,
                        slidesToScroll: 4,
                        infinite: true,
                        dots: true
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 3,
                        slidesToScroll: 3
                    }
                },
                {
                    breakpoint: 480,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2
                    }
                }
                // You can unslick at a given breakpoint now by adding:
                // settings: "unslick"
                // instead of a settings object
            ]
        });

       // alert("hello world 2");
    });

</script>