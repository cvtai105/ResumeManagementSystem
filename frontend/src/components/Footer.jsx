import React from 'react'
import logo from '../assets/logo.svg'

const Footer = () => {
  return (
    <footer className="bg-alice-blue px-[5vw] py-5 mt-20 z-10 mx-auto bottom-0">
      <div className="container grid grid-cols-12 gap-3 items-start">
        <img src={logo} alt="Logo" className="w-[105px] col-span-3" />
        <div className="ml-5 col-span-5 font-bold w-1/2 my-auto">
          <p className="text-xl mb-5">Quản trị viên</p>
          <div className="flex flex-col gap-2">
            <p className="flex justify-between">
              <span>qtv1@gmail.com</span>
              <span>0123546789</span>
            </p>
            <div className="border border-smoke w-full"></div>
            <p className="flex justify-between">
              <span>qtv2@gmail.com</span>
              <span>0987654321</span>
            </p>
          </div>
        </div>
        <div className="col-span-4 font-bold w-1/2 my-auto">
          <p className="text-xl mb-5">Giám đốc</p>
          <div className="flex flex-col gap-2">
            <p className="flex justify-between">
              <span>head1@gmail.com</span>
              <span>0123546789</span>
            </p>
            <div className="border border-smoke w-full"></div>
            <p className="flex justify-between">
              <span>head2@gmail.com</span>
              <span>0123546789</span>
            </p>
          </div>
        </div>
      </div>
    </footer>
  )
}

export default Footer