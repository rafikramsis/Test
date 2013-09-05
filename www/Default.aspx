<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<link href='<%= ResolveClientUrl("~/css/main.css") %>' rel="stylesheet" />
	<link href='<%= ResolveClientUrl("~/css/ie.css") %>' rel="stylesheet" />
	<link href='<%= ResolveClientUrl("~/css/jcarousel.simple.css") %>' rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
	<%--------------------------------- Banner ---------------------------------------%>

	<section id="banner">
		<div id="homeSlides">
			<div class="slides_container">
				<div>
					<img src='<%= ResolveClientUrl("~/photos/banners/banner.jpg") %>' alt="Al Saraya Resort" />
				</div>
				<div>
					<img src='<%= ResolveClientUrl("~/photos/banners/banner-5.jpg") %>' alt="Al Saraya Resort" />
				</div>
				<div>
					<img src='<%= ResolveClientUrl("~/photos/banners/banner-4.jpg") %>' alt="Al Saraya Resort" />
				</div>
			</div>
		</div>

		<%----------------------------- Form ----------------------%>


		<section class="form">
			<h2 class="alignLeft">
				<asp:Localize ID="locReciveBestOffer" runat="server" meta:resourcekey="locReciveBestOfferResource1"
					Text="Receive our best offer:"></asp:Localize></h2>
			<label for="txtName">
				<asp:Localize ID="locName" runat="server" meta:resourcekey="locNameResource1" Text="Name"></asp:Localize></label>
			<input type="text" id="txtName" runat="server" class="validate[required]" /><br />

			<label for="email">
				<asp:Localize ID="locEmail" runat="server" meta:resourcekey="locEmailResource1" Text="Email"></asp:Localize></label>
			<input type="text" id="txtEmail" runat="server" class="validate[required,custom[email]]" /><br />

			<label for="txtPhone">
				<asp:Localize ID="locPhone" runat="server" meta:resourcekey="locPhoneResource1" Text="Phone"></asp:Localize></label>
			<input type="text" id="txtPhone" runat="server" placeholder="Please include your country code"
				class="validate[required]" /><br />

			<label for="txtMessage">
				<asp:Localize ID="locMessage" runat="server" meta:resourcekey="locMessageResource1"
					Text="Message"></asp:Localize></label>
			<textarea id="txtMessage" runat="server" class="validate[required]"></textarea><br />

			<a href="javascript:{}" onclick="javascript:clearForm();">
				<asp:Localize ID="locClear" runat="server" meta:resourcekey="locClearResource1" Text="Clear the form"></asp:Localize></a>

			<%--<input class="button floatR" type="button" value="Send" />--%>
			<asp:Button Text="Send" runat="server" CssClass="button floatR" ID="btnSendContact"
				OnClientClick="validateContactRequest();" OnClick="btnSendContact_Click" meta:resourcekey="btnSendContactResource1" />
		</section>

	</section>

	<%------------------------------------------ Main Content ----------------------------------%>
	<section class="intro">
        <a class="virtualTour" href="http://www.360tourist.net/view-tour/3970/360wa512ccae1eba3c" target="_blank" title="take virtual tour"></a>
		<h1>
			<asp:Localize ID="locWelcomeNote" runat="server" meta:resourcekey="locWelcomeNoteResource1"
				Text="Welcome to
			&lt;br /&gt;
            Al Saraya Resort "></asp:Localize></h1>

		<p>
			<asp:Localize ID="locFirstPargraph" runat="server" meta:resourcekey="locFirstPargraphResource1"
				Text="  Al Saraya resort is a new emerging development inside Sahl Hasheesh international
			resort. 
            Sahl Hasheesh is a purpose-built paradise on the Red Sea Riviera and is set to be
			the largest fully integrated 
            resort community on the Red Sea Coast in Egypt, it is considered by many to be the
			”Jewel of the Red Sea” that 
            has revealed a new concept of luxury, relaxation &amp; recreation."></asp:Localize>
		</p>

		<p>
			<asp:Localize ID="locSecondPargraph" runat="server" meta:resourcekey="locSecondPargraphResource1"
				Text="  Al Saraya comprises 500 affordable luxury apartments with serene partial sea, golf
			&amp; pool views.  
            Property types vary from spacious studios to 3 bedroom deluxe apartments, each designed
			with the highest 
            European quality standards and stunningly elegant style. Complemented with outdoor
			pools (Sea water included), 
            gym, golf course, spa and recreational facilities."></asp:Localize>
		</p>

		<p>
			<asp:Localize ID="locLastPargraph" runat="server" meta:resourcekey="locLastPargraphResource1"
				Text=" Conveniently  located Just 15 minutes from  Hurghada International Airport and a
			short walk from Sahl Hasheesh 
            bay,a waterfront haven is stretched along a 9 km beach promenade that includes range
			of Superb shops, restaurants, 
            cafes, bazaars and water sports facilities, in addition to nightly entertainment
			at the Bay’s Welcome Piazza. "></asp:Localize>
		</p>

		<br class="clear" />

	</section>

	<section class="highlight">

		<h2>
			<asp:Localize ID="locQuickHighlights" runat="server" meta:resourcekey="locQuickHighlightsResource1"
				Text="Quick Highlights"></asp:Localize>
		</h2>
		<ul id="highlights" class="floatL">
			<li>
				<asp:Localize ID="locSwimmingPools" runat="server" meta:resourcekey="locSwimmingPoolsResource1"
					Text="4 big swimming pools"></asp:Localize></li>
			<li>
				<asp:Localize ID="locSaltLake" runat="server" meta:resourcekey="locSaltLakeResource1"
					Text="A salt lake"></asp:Localize></li>
			<li>
				<asp:Localize ID="locGreenLandScaped" runat="server" meta:resourcekey="locGreenLandScapedResource1"
					Text="Green landscaped ground"></asp:Localize></li>
			<li>
				<asp:Localize ID="locCommunal" runat="server" meta:resourcekey="locCommunalResource1"
					Text="Communal sun area with barbeque area"></asp:Localize></li>
			<li>
				<asp:Localize ID="locGolfCource" runat="server" meta:resourcekey="locGolfCourceResource1"
					Text="Access to the golf courses and club house"></asp:Localize></li>
			<li>
				<asp:Localize ID="locSahlHasheesh" runat="server" meta:resourcekey="locSahlHasheeshResource1"
					Text="Access to the beaches of Sahl Hasheesh"></asp:Localize></li>
			<li>
				<asp:Localize ID="locBus" runat="server" meta:resourcekey="locBusResource1" Text="Shuttle bus to the beach"></asp:Localize>
			</li>
			<li>
				<asp:Localize ID="locSecurity" runat="server" meta:resourcekey="locSecurityResource1"
					Text="24 security service"></asp:Localize></li>
			<li>
				<asp:Localize ID="locResort" runat="server" meta:resourcekey="locResortResource1"
					Text="Resort management and maintenance"></asp:Localize></li>
			<li>
				<asp:Localize ID="locKidsClub" runat="server" meta:resourcekey="locKidsClubResource1"
					Text="Kids club"></asp:Localize></li>

			<li>
				<asp:Localize ID="locInternetConnection" runat="server" meta:resourcekey="locInternetConnectionResource1"
					Text="Internet connection in all the apartments"></asp:Localize></li>
			<li>
				<asp:Localize ID="locSatelliteTv" runat="server" meta:resourcekey="locSatelliteTvResource1"
					Text="Satellite TV connection in every apartment"></asp:Localize></li>
			<li>
				<asp:Localize ID="locWellness" runat="server" meta:resourcekey="locWellnessResource1"
					Text="Wellness center and spa"></asp:Localize></li>
			<li>
				<asp:Localize ID="locRestaurant" runat="server" meta:resourcekey="locRestaurantResource1"
					Text="Restaurant and coffee shop"></asp:Localize></li>
			<li>
				<asp:Localize ID="locRoof" runat="server" meta:resourcekey="locRoofResource1" Text="Roof Sky Club"></asp:Localize>
			</li>
			<li>
				<asp:Localize ID="locPrivateGarden" runat="server" meta:resourcekey="locPrivateGardenResource1"
					Text="Private garden for the ground level apartments"></asp:Localize></li>
			<li>
				<asp:Localize ID="locSUpermarket" runat="server" meta:resourcekey="locSUpermarketResource1"
					Text="Supermarket"></asp:Localize></li>
			<li>
				<asp:Localize ID="locParkingFacilities" runat="server" meta:resourcekey="locParkingFacilitiesResource1"
					Text="Parking facilities"></asp:Localize></li>
		</ul>
		<br class="clear" />
	</section>
	<section class="gallery">
		<div class="carousel-wrapper">
			<div data-jcarousel="true" data-wrap="circular" class="carousel">
				<ul id="mycarousel">
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/1.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/1.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/2.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/2.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/3.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/3.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/4.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/4.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/5.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/5.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/6.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/6.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/7.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/7.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/8.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/8.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/9.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/9.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/10.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/10.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/11.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/11.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/12.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/12.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/13.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/13.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/27.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/27.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/15.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/15.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/26.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/26.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/17.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/17.jpg") %>' alt="Al Saraya Resort photos" /></a>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/18.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/18.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/19.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/19.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/20.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/20.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/21.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/21.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/22.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/22.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					<li>
						<a href='<%= ResolveClientUrl("~/photos/gallery/big/23.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/23.jpg") %>' alt="Al Saraya Resort photos" /></a>

						<a href='<%= ResolveClientUrl("~/photos/gallery/big/24.jpg") %>' rel="lightbox[gallery]">
							<img src='<%= ResolveClientUrl("~/photos/gallery/small/24.jpg") %>' alt="Al Saraya Resort photos" /></a>
					</li>
					
				</ul>
			</div>
			<a data-jcarousel-control="true" data-target="-=1" href="#" class="carousel-control-prev">
				&lsaquo;</a>
			<a data-jcarousel-control="true" data-target="+=1" href="#" class="carousel-control-next">
				&rsaquo;</a>

		</div>
		<br class="clear" />
	</section>

	<section class="hotels">
		<h2>
			<asp:Localize ID="locHotels" runat="server" meta:resourcekey="locHotelsResource1"
				Text="Hotels"></asp:Localize></h2>
		<br class="clear" />

		<img src='<%= ResolveClientUrl("~/images/hotels/pyramisa.jpg") %>' alt="Pyramisa Beach Resort" />

		<img src='<%= ResolveClientUrl("~/images/hotels/old-palace-resort.jpg") %>' alt="Old Palace Resort" />

		<img src='<%= ResolveClientUrl("~/images/hotels/premier-le-reve.jpg") %>' alt="Premier Le Reve" />

		<img src='<%= ResolveClientUrl("~/images/hotels/premier-romance.jpg") %>' alt="Premier Romance" />

		<img src='<%= ResolveClientUrl("~/images/hotels/tropitel.jpg") %>' alt="Tropitel Sahl Hasheesh" />

		<%--<a href="#" title="visit our sponsors" target="_blank">
			<img src='<%= ResolveClientUrl("~/images/hotels/sahl-hasheesh.jpg") %>' alt="pyramisa beach resort" /></a>--%>
	</section>


	<section id="exclusiveAgent" class="hotels">
		<h2>
			<asp:Localize runat="server" ID="locExclusiveAgent" meta:resourcekey="locExclusiveAgent"></asp:Localize>
		</h2>
		<br class="clear" />
		<%--<a href="http://www.estate-alliance.com" title="visit our exclusive agent"
			target="_blank">--%>
		<img class="floatL" src='<%= ResolveClientUrl("~/images/estateAlliance-logo.png") %>'
			alt="Estate Alliance" />
		<%--</a>--%>

		<br class="clear" />
	</section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="Server">
	<script src='<%= ResolveClientUrl("~/scripts/slides.min.jquery.js") %>' type="text/javascript"></script>
	<script src='<%= ResolveClientUrl("~/scripts/jquery.jcarousel.min.js") %>' type="text/javascript"></script>
	<script>
		$(".form").bind("jqv.form.result", function (event, errorFound) {
			if (errorFound) alert("There is a problem with your form");
		});

		function clearForm() {
			$(":text").add("textarea").val('');
			if ($(".formError").length > 0)
				$(".formError").remove();
		}

		function validateContactRequest() {
			$("#form1").validationEngine({ relative: true });
			return $("#form1").validationEngine('validate');
		}

		$(document).ready(function () {
			$('#homeSlides').slides({
				preload: true,
				//container: 'homeslides',
				paginationClass: 'bannerRotation',
				currentClass: 'active',
				preloadImage: '<%= GetLocalizedUrl("~/images/loading.gif") %>',
				effect: 'fade',
				crossfade: true,
				slideSpeed: 35000,
				fadeSpeed: 500,
				generateNextPrev: false,
				generatePagination: true,
				play: 5000,
			});

			// remove page numbers
			$(".bannerRotation li a").html("");
		});

		(function ($) {
			$(function () {
				$('[data-jcarousel]').each(function () {
					var el = $(this);
					el.jcarousel(el.data());
				});

				$('[data-jcarousel-control]').each(function () {
					var el = $(this);
					el.jcarouselControl(el.data());
				});
			});
		})(jQuery);


	</script>
</asp:Content>

