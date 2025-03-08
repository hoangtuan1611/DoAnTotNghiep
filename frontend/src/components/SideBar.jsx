import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { Layout, Menu, Button } from "antd";
import {
  DesktopOutlined,
  FileOutlined,
  PieChartOutlined,
  TeamOutlined,
  UserOutlined,
  MenuUnfoldOutlined,
  MenuFoldOutlined,
} from "@ant-design/icons";
import { motion } from "framer-motion";

const { Content, Sider } = Layout;

const siderStyle = {
  height: "100vh",
  position: "sticky",
  insetInlineStart: 0,
  top: 0,
  bottom: 0,
  backgroundColor: "#212529",
};

const SideBar = React.memo(() => {
  const [collapsed, setCollapsed] = useState(true);
  // const [selectedKey, setSelectedKey] = useState("1");
  const navigate = useNavigate();

  function getItem(label, key, icon, children) {
    return {
      key,
      icon,
      children,
      label,
    };
  }

  const items = [
    getItem("Home", "1", <PieChartOutlined />),
    getItem("Class managerment", "2", <DesktopOutlined />),
    getItem("Statistics", "3", <FileOutlined />),
    getItem("User", "sub1", <UserOutlined />, [
      getItem("Tom", "4"),
      getItem("Bill", "5"),
      getItem("Alex", "6"),
    ]),
    getItem("Team", "sub2", <TeamOutlined />, [
      getItem("Team 1", "7"),
      getItem("Team 2", "8"),
    ]),
  ];

  const handleOnclick = (e) => {
    switch (e.key) {
      case "1":
        navigate("/home-page");
        break;
      case "2":
        navigate("/class-managerment");
        break;
      case "3":
        navigate("/statistics");
        break;

      default:
        break;
    }
  };

  return (
    <Sider
      collapsed={collapsed}
      onCollapse={(value) => setCollapsed(value)}
      style={siderStyle}
    >
      <div>
        <div>
          <div
            style={{
              display: "flex",
              justifyContent: "space-between",
              alignItems: "center",
              margin: "0.5rem 1.2rem",
              fontSize: "1.5rem",
            }}
          >
            {!collapsed && (
              <motion.p
                initial={{ opacity: 0, x: -10 }}
                animate={{ opacity: collapsed ? 0 : 1, x: collapsed ? -10 : 0 }}
                transition={{ duration: 0.3 }}
                style={{ color: "white", whiteSpace: "nowrap" }}
              >
                Manager
              </motion.p>
            )}
            <Button
              style={{
                fontSize: "1.5rem",
                backgroundColor: "transparent",
                color: "white",
                border: "none",
                padding: 0,
                marginLeft: "0.5rem",
              }}
              onClick={() => setCollapsed(!collapsed)}
            >
              {collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
            </Button>
          </div>
          <div>
            <Menu
              theme="dark"
              // defaultSelectedKeys={[selectedKey]}
              mode="inline"
              items={items}
              style={{ backgroundColor: "#212529" }}
              onClick={(e) => handleOnclick(e)}
            />
          </div>
        </div>
        <div></div>
      </div>
    </Sider>
  );
});

export default SideBar;
