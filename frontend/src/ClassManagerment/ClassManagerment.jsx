import { Layout, List } from 'antd'
import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import SideBar from '../components/SideBar'
import History from '../History/History'

const timeTableApi = import.meta.env.VITE_API_TIMETABLE
const teacherCode = localStorage.getItem('TeacherCode') ?? '000.000.00000'

function ClassManagerment() {
  const [timeTable, setTimeTable] = useState([])

  const navigate = useNavigate()

  const fetchData = async () => {
    try {
      var result = await axios.get(`${timeTableApi}/${teacherCode}`)
      if (result.data && result.data.length > 1) {
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

  const handleDetail = (item) => {
    navigate(
      `/history?subject=${encodeURIComponent(
        item.subject.subjectName
      )}&class=${encodeURIComponent(item.schedule.className)}&scheduleId=${
        item.schedule.id
      }&maxStudents=${item.schedule.maxStudents}`
    )
  }

  return (
    <Layout style={{ minHeight: '100vh', minWidth: '100vw', display: 'flex' }}>
      <SideBar />
      <Layout style={{ flex: 1 }}>
        <div className="h-auto bg-gradient-to-br from-blue-50 to-indigo-50 p-6">
          <div className="flex items-center justify-between">
            <h1 className="mb-6 text-3xl font-bold text-indigo-900">
              Quản lý lớp học
            </h1>
          </div>
          <div className="tab">
            <div className="rounded-lg bg-blue-100 pt-6 pb-6">
              <h1 className="mb-3 ml-6">Danh sách lớp học</h1>
              <div className="bg-white pt-1 pr-6 pb-1 pl-6">
                <List
                  itemLayout="horizontal"
                  dataSource={timeTable}
                  renderItem={(item, index) => (
                    <List.Item
                      onClick={() => handleDetail(item)}
                      className="mt-3 mb-3 flex flex-col !items-start rounded-lg bg-blue-50"
                    >
                      <List.Item.Meta
                        className="pl-6"
                        title={
                          <span className="text-base text-indigo-900">
                            {item.subject.subjectName}
                          </span>
                        }
                        style={{ whiteSpace: 'nowrap' }}
                      />
                      <div className="flex flex-col pl-6">
                        <span className="text-base text-indigo-900">
                          {item.schedule.className}
                        </span>
                        <span>
                          Phòng: {item.room} - Sỉ số:{' '}
                          {item.schedule.maxStudents}
                        </span>
                      </div>
                    </List.Item>
                  )}
                />
              </div>
            </div>
          </div>
        </div>
      </Layout>
    </Layout>
  )
}

export default ClassManagerment
