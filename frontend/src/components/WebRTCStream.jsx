import React, { useEffect, useRef } from "react";

function WebRTCStream() {
  const videoRef = useRef(null);

  useEffect(() => {
    const startWebRTC = async () => {
      // Create a new RTCPeerConnection
      const pc = new RTCPeerConnection();

      // Get the video stream from the user's camera
      const stream = await navigator.mediaDevices.getUserMedia({ video: true });
      stream.getTracks().forEach(track => pc.addTrack(track, stream));

      // Display the video stream in the video element
      if (videoRef.current) {
        videoRef.current.srcObject = stream;
      }

      // Handle signaling and connection setup here
      // This includes creating an offer, setting local/remote descriptions, etc.

      // Example: Create an offer and send it to the server
      const offer = await pc.createOffer();
      await pc.setLocalDescription(offer);

      // Send the offer to the server (implement signaling logic here)
      // Example: Use WebSocket or HTTP to send the offer to the server
    };

    startWebRTC();

    return () => {
      // Clean up resources on component unmount
      if (videoRef.current && videoRef.current.srcObject) {
        videoRef.current.srcObject.getTracks().forEach(track => track.stop());
      }
    };
  }, []);

  return <video ref={videoRef} autoPlay playsInline className="w-full h-full" />;
}

export default WebRTCStream;