import React from "react";

function Home() {
  return (
    <div className="w-screen h-screen bg-linear-to-r/srgb from-cyan-100 to-zinc-200">
      <div className="bg-gray-50 flex flex-col justify-center items-center w-1/2 rounded-2xl !p-4">
        <h1 className="text-3xl w-1/2 text-center !mb-4.5">
          Ứng dụng quản lý sinh viên trong phòng thực hành
        </h1>
        <p>
          Theo dõi phân tích và quản lý số lượng sinh viên theo thời gian thực
        </p>
      </div>
    </div>
  );
}

export default Home;
