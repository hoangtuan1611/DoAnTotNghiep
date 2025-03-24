import React from "react";

function VideoStream() {
  return (
    <div className="h-72 flex items-center justify-center bg-gray-200 rounded-lg">
      <img
        src="http://localhost:5000/video_feed"
        alt="Live Stream"
        className="w-full h-full object-cover rounded-lg"
      />
    </div>
  );
}

export default VideoStream;
