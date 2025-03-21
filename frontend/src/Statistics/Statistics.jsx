import { Layout, DatePicker, Button } from 'antd'
import React, { useEffect, useState } from 'react'
import axios from 'axios'
import SideBar from '../components/SideBar'
import dayjs from 'dayjs'
import LineChartCustom from '../components/LineChartCustom'
import BarChartCustom from '../components/BarChartCustom'

const apiCourse = import.meta.env.VITE_API_COURSE
const apiClass = import.meta.env.VITE_API_CLASS

// const className = ["CTK45A", "CTK45B", "CTK46A", "CTK46B"];
// const courseName = [
//   "Lập trình Python",
//   "Hướng đối tượng",
//   "Ứng dụng desktop",
//   "Dữ liệu và thuật giải",
// ];
const dataChart = [
  { time: 'Buổi 2 (02/02/2025)', count: '30' },
  { time: 'Buổi 3 (03/02/2025)', count: '80' },
  { time: 'Buổi 4 (04/02/2025)', count: '55' },
  { time: 'Buổi 5 (02/02/2025)', count: '30' },
  { time: 'Buổi 6 (02/02/2025)', count: '30' },
  { time: 'Buổi 7 (02/02/2025)', count: '30' },
]

function Statistics() {
  const [courseName, setCourseName] = useState([])
  const [className, setClassName] = useState([])

  const getCourse = async () => {
    const result = await axios.get(apiCourse)
    const course = result.data.map((item) => item.courseName)
    setCourseName(course)
  }

  const getClass = async () => {
    const result = await axios.get(apiClass)
    const data = result.data.map((item) => item.classId)
    setClassName(data)
  }

  useEffect(() => {
    getCourse()
    getClass()
  }, [])

  return (
    <Layout style={{ minHeight: '100vh', minWidth: '98vw' }}>
      <SideBar />
      <Layout>
        <div className="flex h-auto flex-col gap-6 bg-gradient-to-br from-blue-50 to-indigo-50 p-6">
          <div className="datetime flex justify-end">
            <DatePicker
              style={{ margin: '1rem' }}
              format={'DD-MM-YYYY HH:mm'}
              inputReadOnly={true}
              allowClear={false}
              defaultValue={dayjs()}
            />
            <DatePicker
              style={{ margin: '1rem' }}
              format={'DD-MM-YYYY HH:mm'}
              inputReadOnly={true}
              allowClear={false}
              defaultValue={dayjs()}
            />
          </div>
          <div className="rounded-2xl bg-white p-10 backdrop-blur-sm transition-all duration-300 hover:shadow-lg">
            <div className="class mb-2">
              <h1 className="bg-gradient-to-r from-indigo-600 via-purple-600 to-blue-600 bg-clip-text text-2xl font-bold text-transparent">
                Báo cáo theo môn học
              </h1>
              <p className="text-base">Chọn lớp để xem thống kê</p>
            </div>
            <div className="mb-5 grid grid-cols-2 gap-4">
              {className.map((item, index) => (
                <Button
                  style={{ backgroundColor: '#6366F1' }}
                  key={index}
                  block
                  type="primary"
                  htmlType="submit"
                >
                  {item}
                </Button>
              ))}
            </div>
            <div className="course">
              <p className="mb-2 text-base">Chọn môn học</p>
              <div className="grid grid-cols-2 gap-4">
                {courseName.map((item, index) => (
                  <Button
                    style={{ backgroundColor: '#3B82F6' }}
                    key={index}
                    block
                    type="primary"
                    htmlType="submit"
                  >
                    {item}
                  </Button>
                ))}
              </div>
            </div>
            <div className="chart mt-10 h-72">
              <LineChartCustom data={dataChart} />
            </div>
          </div>
          <div className="lecturer rounded-2xl bg-white p-10 backdrop-blur-sm transition-all duration-300 hover:shadow-lg">
            <h1 className="mb-2 bg-gradient-to-r from-indigo-600 via-purple-600 to-blue-600 bg-clip-text text-2xl font-bold text-transparent">
              Báo cáo theo giáo viên
            </h1>
            <div className="h-72">
              <BarChartCustom data={dataChart} />
            </div>
          </div>
        </div>
      </Layout>
    </Layout>
  )
}

export default Statistics
