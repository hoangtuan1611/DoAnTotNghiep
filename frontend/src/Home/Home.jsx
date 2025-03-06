import React, { useEffect, useState } from "react";
import { UserCheck, Activity, Clock } from "lucide-react";
import SideBar from "../components/SideBar";
import { Layout } from "antd";
import Chart from "../components/Chart";

function Home() {
  const [isStreaming, setIsStreaming] = useState(false);
  const [currentCount, setCurrentCount] = useState(20);
  const [currentTime, setCurrentTime] = useState();
  const [historicalData, setHistoricalData] = useState([
    { time: "07:30", count: 10 },
    { time: "08:00", count: 18 },
    { time: "08:30", count: 22 },
    { time: "09:00", count: 25 },
    { time: "09:30", count: 30 },
    { time: "10:00", count: 28 },
    { time: "10:30", count: 27 },
    { time: "11:00", count: 20 },
    { time: "11:30", count: 15 },
  ]);

  useEffect(() => {
    if (isStreaming) {
      const interval = setInterval(() => {
        setCurrentCount((prev) => prev + Math.floor(Math.random() * 3) - 1);
      }, 2000);
      return () => clearInterval(interval);
    }
  }, [isStreaming]);

  useEffect(() => {
    getTime();
  }, []);

  const getTime = () => {
    const now = new Date();
    const hours = now.getHours().toString();
    const minutes = now.getMinutes().toString();
    const currentTime = `${hours}:${minutes}`;
    setCurrentTime(currentTime);
  };

  return (
    <Layout
      style={{
        minHeight: "100vh",
        minWidth: "98vw",
        display: "flex",
      }}
    >
      <SideBar />
      <Layout style={{ flex: 1 }}>
        <div className=" h-auto bg-gradient-to-br from-blue-50 to-indigo-50 pt-6 pb-6">
          <div className="header text-center mb-16">
            <h1 className="font-bold text-2xl bg-gradient-to-r from-indigo-600 via-purple-600 to-blue-600 bg-clip-text text-transparent">
              Ứng Dụng Quản Lý Sinh Viên Trong Phòng Thực Hành
            </h1>
            <p className="text-lg">
              Theo dõi, phân tích và quản lý số lượng sinh viên theo thời gian
              thực
            </p>
          </div>
          <div className="State">
            <div className="flex m-8">
              <div className="flex flex-1 justify-center">
                <UserCheck className="text-blue-600 mr-3.5" />
                <p className="text-blue-600 text-lg">
                  Sinh viên có mặt {currentCount}
                </p>
              </div>
              <div className="flex flex-1 justify-center">
                <Activity className="text-green-600 mr-3.5" />
                <p className="text-green-600 text-lg">Tỷ lệ tham gia 85%</p>
              </div>
              <div className="flex flex-1 justify-center">
                <Clock className="text-purple-600 mr-3.5" />
                <p className="text-purple-600 text-lg">
                  Thời gian hiện tại {currentTime}
                </p>
              </div>
            </div>
          </div>
          <div className="camera chart flex flex-col gap-8">
            <div className="camera flex-1 w-[70vw] bg-white/50 backdrop-blur-sm hover:shadow-lg transition-all duration-300 p-3 m-auto">
              <p className="mb-3 text-base text-indigo-900">Theo dõi camera</p>
              <div className="h-72 flex items-center justify-center bg-gray-200 rounded-lg">
                {isStreaming ? (
                  <p className="text-green-600">Live Stream</p>
                ) : (
                  <p className="text-gray-500">Camera tắt</p>
                )}
              </div>
              <div className="flex justify-center items-center">
                <button
                  className="bg-blue-500 w-32 text-white p-2.5 mt-2.5 rounded-md"
                  onClick={() => setIsStreaming(!isStreaming)}
                >
                  {isStreaming ? "Tắt camera" : "Bật camera"}
                </button>
              </div>
            </div>
            <div className="chart flex-1 w-[70vw] bg-white/50 backdrop-blur-sm hover:shadow-lg transition-all duration-300 p-3 m-auto">
              <p className="mb-3 text-base text-indigo-900">Biểu đồ theo dõi</p>
              <div className="h-72">
                <Chart data={historicalData} />
              </div>
            </div>
          </div>
        </div>
      </Layout>
    </Layout>
  );
}

export default Home;
