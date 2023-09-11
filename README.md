# Proof of Concept: OneTouch's MetaHealth

This is a proof of concept made for the OneTouch's Metahealth project! It consists in a AR experience for the Microsoft's
HoloLens2 based on a medical surgery for babies who were born with macrocephaly. The POC was made with Unity. <br>

<h1> Goals </h1>
<p>
	This POC had two main goals: <br>
	<b> 1: To have a multiplayer lobby where multiple HoloLens are able to connect and see objects asynchronously. </b> <br>
	<b> 2: To holoportate real-life objects with a Microsoft Azure Kinect DK. </b> <br>
</p>

<h1> Problems </h1>
<p>
	<b> Problem 1: Multiplayer asynchronously lobby </b> <br>
	The idea here was to create a multiplayer lobby where multiple HoloLenses could connect and see the same <br> 
	asynchronously objects. The objects on the scene would be an animated doctor performing a surgery and a <br>
	menu to play, pause and stop the animation. The idea was that people with HoloLens would simply open the <br>
	same build and would connect automatically to the lobby, and all HoloLens connected to the lobby would be <br>
	able to start, play, pause or stop the animation, besides seeing it and hearing it sound.
</p>
<p>
	<b> Problem 2: Holoportation </b> <br>
	For this, we wanted to be able to holoportate objects within a squared space defined by 4 Microsoft Azure <br>
	Kinect DK's cameras. All objects within the square should be able to be seen by someone with a HoloLens that <br>
	was in a different network. We wanted that a doctor in A with a HoloLens, that was contained in the squared <br>
	space mentioned before, should be able a doctor in B with the same conditions, and vice-versa. With that, they <br>
	would be able to help each other easily.
</p>

<h1> Achieved </h1>
<p>
	We were able to achieve the creation of the asynchronously lobby, but we were not able to achieve sharing data <br>
	between clients, even if the clients were in the same network. Also, we were not able to share the holoported data <br>
	across the network, so clients in different networks were not able to see each other's data.
</p>

<h1> Results: Sufficient </h1>
<p>
	We did not achieve what was expected with this first version. However, setting up this POC in the time that we had (only 8 <br>
	days to do everything from scratch!) and making it work on a local machine only (with the asynchronous data) was enough <br>
	based on what's was asked.
</p>
