import React, { useEffect, useState } from "react";
import { io } from "socket.io-client";

function student_count() {
  const [studentCount, setStudentCount] = useState(0);

  useEffect(() => {
    // Establish a WebSocket connection to the backend server
    const socket = io("http://localhost:5000"); // Ensure this URL matches your backend server's address

    // Listen for the 'student_count' event from the server
    socket.on("student_count", (data) => {
      setStudentCount(data.count); // Update the student count state with the received data
    });

    // Clean up the WebSocket connection when the component unmounts
    return () => {
      socket.disconnect();
    };
  }, []); // Empty dependency array ensures this effect runs only once on mount

  return (
    <div>
      <h1>Live Video Stream with Student Count</h1>
      <div>
        <img
          src="http://localhost:5000/video_feed"
          alt="Video Stream"
          style={{ width: "100%", height: "auto" }}
        />
      </div>
      <div>
        <h2>Current Student Count: {studentCount}</h2>
      </div>
    </div>
  );
}

export default student_count;