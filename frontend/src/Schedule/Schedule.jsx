import React, { useEffect, useState } from 'react'
import { Layout } from 'antd'
import axios from 'axios'
import SideBar from '../components/SideBar'
import UpdateClass from './UpdateClass'

function Schedule() {
  const [weekNum, setWeekNum] = useState(0)
  const [startDate, setStartDate] = useState('00/00/0000')
  const [endDate, setEndDate] = useState('00/00/0000')
  const [timeTable, setTimeTable] = useState([])
  const [open, setOpen] = useState(false)
  const [selectedItem, setSelectedItem] = useState()

  const days = [
    'Thứ 2',
    'Thứ 3',
    'Thứ 4',
    'Thứ 5',
    'Thứ 6',
    'Thứ 7',
    'Chủ nhật',
  ]

  const timeTableApi = import.meta.env.VITE_API_TIMETABLE
  const teacherCode = localStorage.getItem('TeacherCode') ?? '000.000.00000'
  const teacherName = localStorage.getItem('TeacherName') ?? 'Teacher'

  const formatDate = (isoString) => {
    const date = new Date(isoString)
    const day = String(date.getDate()).padStart(2, '0')
    const month = String(date.getMonth() + 1).padStart(2, '0')
    const year = date.getFullYear()
    return `${day}/${month}/${year}`
  }

  const fetchData = async () => {
    try {
      var result = await axios.get(`${timeTableApi}/${teacherCode}`)
      if (result.data && result.data.length > 1) {
        setStartDate(formatDate(result.data[0].schedule.startDay))
        setEndDate(formatDate(result.data[0].schedule.endDay))
        setWeekNum(result.data[0].schedule.weekNum)
        setTimeTable(result.data)
      } else {
        console.log('Fail')
        setTimeTable([])
      }
    } catch (error) {
      console.log('Fail to load data')
      setTimeTable([])
    }
  }

  useEffect(() => {
    fetchData()
  }, [])

  const handleCellClick = (item) => {
    setSelectedItem(item)
    setOpen(true)
  }

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
        <div className="h-auto bg-gradient-to-br from-blue-50 to-indigo-50 p-6">
          <div className="flex justify-between">
            <h1 className="text-xl font-bold">
              Tuần {weekNum}: từ ngày {startDate} đến ngày {endDate}
            </h1>
            <p className="text-base">
              Thời khóa biểu giảng viên: {teacherName}
            </p>
          </div>
          <div>
            <table className="mt-4 w-full border-collapse border border-gray-300">
              <colgroup>
                <col className="w-1/10" />
                <col className="w-1/4" />
                <col className="w-1/4" />
                <col className="w-1/4" />
              </colgroup>
              <thead>
                <tr className="w-1.5 bg-gray-100">
                  <th className="h-12 border border-gray-300">Thời gian</th>
                  <th className="h-12 border border-gray-300 p-2">Sáng</th>
                  <th className="h-12 border border-gray-300 p-2">Chiều</th>
                  <th className="h-12 border border-gray-300 p-2">Tối</th>
                </tr>
              </thead>
              <tbody>
                {days.map((day, index) => {
                  const scheduleForDay = timeTable.filter(
                    (item) => item.dayOfWeek === index + 2
                  )

                  return (
                    <tr key={index}>
                      <td className="border border-gray-300 bg-green-500 p-2 text-center text-white">
                        {day}
                      </td>

                      {[0, 1, 2].map((timeOfDay) => {
                        const schedule = scheduleForDay.filter(
                          (item) => item.timeOfDay === timeOfDay
                        )

                        return (
                          <td
                            key={timeOfDay}
                            className="h-32 cursor-pointer border border-gray-300 p-2"
                            onClick={() =>
                              schedule.length > 0 &&
                              handleCellClick(schedule[0])
                            }
                          >
                            {schedule.length > 0
                              ? schedule.map((item, idx) => (
                                  <div key={idx}>
                                    <p className="text-base text-red-600">
                                      {item.subject.subjectName}
                                    </p>
                                    <p>- Lớp: {item.schedule.className}</p>
                                    <p>
                                      - Tiết: {item.periodBegin} -{' '}
                                      {item.periodEnd}
                                    </p>
                                    <p>- Phòng: {item.room}</p>
                                    <p>- Sỉ số: {item.schedule.maxStudents}</p>
                                  </div>
                                ))
                              : null}
                          </td>
                        )
                      })}
                    </tr>
                  )
                })}
              </tbody>
            </table>
          </div>
        </div>
      </Layout>
      {open && selectedItem && (
        <UpdateClass
          item={selectedItem}
          open={open}
          setOpen={setOpen}
          fetchData={fetchData}
        />
      )}
    </Layout>
  )
}

export default Schedule
