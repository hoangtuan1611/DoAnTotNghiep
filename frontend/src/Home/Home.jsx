import React, { useEffect, useState } from 'react'
import { UserCheck, Activity, Clock } from 'lucide-react'
import SideBar from '../components/SideBar'
import { Layout } from 'antd'
import LineChartCustom from '../components/LineChartCustom'

function Home() {
  const [isStreaming, setIsStreaming] = useState(false)
  const [currentCount, setCurrentCount] = useState(20)
  const [currentTime, setCurrentTime] = useState()
  const [historicalData, setHistoricalData] = useState([
    { time: '07:30', count: 10 },
    { time: '08:00', count: 18 },
    { time: '08:30', count: 22 },
    { time: '09:00', count: 25 },
    { time: '09:30', count: 30 },
    { time: '10:00', count: 28 },
    { time: '10:30', count: 27 },
    { time: '11:00', count: 20 },
    { time: '11:30', count: 15 },
  ])
  const maxStudents = 100

  useEffect(() => {
    if (isStreaming) {
      const interval = setInterval(() => {
        setCurrentCount((prev) => prev + Math.floor(Math.random() * 3) - 1)
      }, 2000)
      return () => clearInterval(interval)
    }
  }, [isStreaming])

  useEffect(() => {
    const getTime = () => {
      const now = new Date()
      const hours = now.getHours().toString()
      const minutes = now.getMinutes().toString()
      const currentTime = `${hours}:${minutes}`
      setCurrentTime(currentTime)
      const secondsUntilNextMinute = 60 - now.getSeconds()
      setTimeout(getTime, secondsUntilNextMinute * 1000)
    }

    getTime()

    return () => clearTimeout(getTime)
  }, [])

  return (
    <Layout
      style={{
        minHeight: '100vh',
        minWidth: '98vw',
        display: 'flex',
      }}
    >
      <SideBar />
      <Layout style={{ flex: 1 }}>
        <div className="h-auto bg-gradient-to-br from-blue-50 to-indigo-50 pt-6 pb-6">
          <div className="header mb-16 text-center">
            <h1 className="bg-gradient-to-r from-indigo-600 via-purple-600 to-blue-600 bg-clip-text text-2xl font-bold text-transparent">
              Ứng Dụng Quản Lý Sinh Viên Trong Phòng Thực Hành
            </h1>
            <p className="text-lg">
              Theo dõi, phân tích và quản lý số lượng sinh viên theo thời gian
              thực
            </p>
          </div>
          <div className="State">
            <div className="m-8 flex">
              <div className="flex flex-1 justify-center">
                <UserCheck className="mr-3.5 text-blue-600" />
                <p className="text-lg text-blue-600">
                  Sinh viên có mặt {currentCount}
                </p>
              </div>
              <div className="flex flex-1 justify-center">
                <Activity className="mr-3.5 text-green-600" />
                <p className="text-lg text-green-600">
                  Tỷ lệ tham gia {(currentCount / maxStudents) * 100}%
                </p>
              </div>
              <div className="flex flex-1 justify-center">
                <Clock className="mr-3.5 text-purple-600" />
                <p className="text-lg text-purple-600">
                  Thời gian hiện tại {currentTime}
                </p>
              </div>
            </div>
          </div>
          <div className="camera chart flex flex-col gap-8">
            <div className="camera m-auto w-[70vw] flex-1 bg-white/50 p-3 backdrop-blur-sm transition-all duration-300 hover:shadow-lg">
              <p className="mb-3 text-base text-indigo-900">Theo dõi camera</p>
              <div className="flex h-72 items-center justify-center rounded-lg bg-gray-200">
                {isStreaming ? (
                  <p className="text-green-600">Live Stream</p>
                ) : (
                  <p className="text-gray-500">Camera tắt</p>
                )}
              </div>
              <div className="flex items-center justify-center">
                <button
                  className="mt-2.5 w-32 rounded-md bg-blue-500 p-2.5 text-white"
                  onClick={() => setIsStreaming(!isStreaming)}
                >
                  {isStreaming ? 'Tắt camera' : 'Bật camera'}
                </button>
              </div>
            </div>
            <div className="chart m-auto w-[70vw] flex-1 bg-white/50 p-3 backdrop-blur-sm transition-all duration-300 hover:shadow-lg">
              <p className="mb-3 text-base text-indigo-900">Biểu đồ theo dõi</p>
              <div className="h-72">
                <LineChartCustom data={historicalData} />
              </div>
            </div>
          </div>
        </div>
      </Layout>
    </Layout>
  )
}

export default Home
