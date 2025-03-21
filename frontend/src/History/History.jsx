import React, { useEffect, useState } from 'react'
import dayjs from 'dayjs'
import { List, DatePicker, Layout } from 'antd'
import axios from 'axios'
import LineChartCustom from '../components/LineChartCustom'
import SideBar from '../components/SideBar'
import { useSearchParams } from 'react-router-dom'

const historyList = [
  {
    class: 'CTK45A',
    time: '7:30 - 9:30',
    data: [
      { time: '07:30', count: 10 },
      { time: '08:00', count: 18 },
      { time: '08:30', count: 22 },
      { time: '09:00', count: 25 },
      { time: '09:30', count: 30 },
    ],
  },
  {
    class: 'CTK45B',
    time: '7:30 - 9:30',
    data: [
      { time: '07:30', count: 10 },
      { time: '08:00', count: 18 },
      { time: '08:30', count: 22 },
      { time: '09:00', count: 25 },
      { time: '09:30', count: 30 },
    ],
  },
]

const attendanceLogApi = import.meta.env.VITE_API_ATTENDANCE_LOG

function History() {
  const [data, setData] = useState([])
  const [logData, setLogData] = useState([])

  const [searchParams] = useSearchParams()
  const subjectName = searchParams.get('subject') || 'N/A'
  const className = searchParams.get('class') || 'N/A'
  const scheduleId = searchParams.get('scheduleId') || 'N/A'
  const maxStudents = searchParams.get('maxStudents') || 100

  const fetchData = async () => {
    try {
      const api = `${attendanceLogApi}/by-scheduleId?scheduleId=${scheduleId}`
      const result = await axios.get(api)
      setData(result.data)
      console.log(result.data)
    } catch (error) {
      console.error('Lỗi khi fetch dữ liệu:', error)
    }
  }

  useEffect(() => {
    fetchData()
  }, [])

  const handleDetail = (data) => {
    setLogData(data)
  }

  return (
    <Layout style={{ minHeight: '100vh', minWidth: '100vw', display: 'flex' }}>
      <SideBar />
      <Layout style={{ flex: 1 }}>
        <div className="h-auto bg-gradient-to-br from-blue-50 to-indigo-50 p-6">
          <div className="mb-6 text-2xl font-bold text-indigo-900">
            <p>{subjectName}</p>
            <p>{className}</p>
          </div>
          <div className="flex gap-6">
            <div className="flex-1 rounded-lg bg-white">
              <div className="flex h-fit items-start justify-between">
                <p className="p-3 text-base text-indigo-900">Lịch sử lớp học</p>
                <DatePicker
                  style={{ margin: '1rem' }}
                  format={'DD-MM-YYYY'}
                  inputReadOnly={true}
                  allowClear={false}
                  defaultValue={dayjs()}
                />
              </div>
              <div className="mr-5 ml-5">
                <List
                  itemLayout="horizontal"
                  dataSource={data}
                  renderItem={(item, index) => (
                    <List.Item
                      className="mt-3 mb-3 flex flex-col !items-start rounded-lg bg-blue-50"
                      onClick={() => handleDetail(item.logData)}
                    >
                      <List.Item.Meta
                        className="pl-6"
                        title={<a href="">{item.date}</a>}
                      />
                    </List.Item>
                  )}
                />
              </div>
            </div>
            <div className="chart flex-2 rounded-lg bg-white">
              <p className="p-3 text-base text-indigo-900">
                Thống kê điểm danh
              </p>
              <div className="h-72">
                <LineChartCustom data={logData} />
              </div>
            </div>
          </div>
        </div>
      </Layout>
    </Layout>
  )
}

export default History

// const classList = [
//   {
//     class: "CTK45A",
//     room: "A24.1",
//     maxStudents: 30,
//     courseName: "Lập trình python",
//   },
//   {
//     class: "CTK45B",
//     room: "A24.1",
//     maxStudents: 25,
//     courseName: "Hướng đối tượng",
//   },
// ];
