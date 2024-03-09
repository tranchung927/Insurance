import React, { useState } from 'react';
import '../styles/payment.css';

function PaymentDetails() {
    const [selectedTab, setSelectedTab] = useState('payment-tab1');
    const [selectedId, setSelectedId] = useState('hcm');

    const handleTabClick = (tabId) => {
        setSelectedTab(tabId);
    };

    const handleAreaChange = (e) => {
        setSelectedId(e.target.value);
    };

    return (
        <div className="container">
            <ul className="payment-tabs">
                <li className={selectedTab === 'payment-tab1' ? 'payment-tab-item active' : 'payment-tab-item'} data-tab="payment-tab1" onClick={() => handleTabClick('payment-tab1')}>
                    <i className="fa-solid fa-building" style={{ color: '#67ad8b' }}></i>
                    Online payment
                </li>
                <li className={selectedTab === 'payment-tab2' ? 'payment-tab-item active' : 'payment-tab-item'} data-tab="payment-tab2" onClick={() => handleTabClick('payment-tab2')}>
                    <i className="fa-solid fa-wallet" style={{ color: '#67ad8b' }}></i>
                    Electronic wallet
                </li>
                <li className={selectedTab === 'payment-tab3' ? 'payment-tab-item active' : 'payment-tab-item'} data-tab="payment-tab3" onClick={() => handleTabClick('payment-tab3')}>
                    <i className="fa-solid fa-building-columns" style={{ color: '#67ad8b' }}></i>
                    Bank
                </li>
                <li className={selectedTab === 'payment-tab4' ? 'payment-tab-item active' : 'payment-tab-item'} data-tab="payment-tab4" onClick={() => handleTabClick('payment-tab4')}>
                    <i className="fa-solid fa-credit-card" style={{ color: '#67ad8b' }}></i>
                    Direct collection
                </li>
                <li className={selectedTab === 'payment-tab5' ? 'payment-tab-item active' : 'payment-tab-item'} data-tab="payment-tab5" onClick={() => handleTabClick('payment-tab5')}>
                    <i className="fa-solid fa-envelopes-bulk" style={{ color: '#67ad8b' }}></i>
                    Via Vn Post
                </li>
                <li className={selectedTab === 'payment-tab6' ? 'payment-tab-item active' : 'payment-tab-item'} data-tab="payment-tab6" onClick={() => handleTabClick('payment-tab6')}>
                    <i className="fa-solid fa-store" style={{ color: '#67ad8b' }}></i>
                    Affiliate store
                </li>
            </ul>
            <div className="content-tab">
                <div className={selectedTab === 'payment-tab1' ? 'payment-tab-content' : 'payment-tab-content hidden'} id="payment-tab1">
                    {/* Nội dung cho tab 1 */}
                    <h1>Online payment</h1>
                    <img className="imgpt1" src="https://www.cathaylife.com.vn/cathay/img/service/pay-click.png" alt="Pay" />
                    <p className='pmt1'>- Customers can use ATM/ Visa/ Master Card/ JCB... to make payment of periodic Insurance Premium and first Insurance Premium.
                        <br /><br />- Your payment request will be further processed by the ATM card issuing bank or CyberSource, the world's largest payment management company (part of VISA organization)
                        <br /><br />- We does not directly store your card. To ensure safety, all of your card information is only saved by CyberSource, the world's largest payment management company (part of VISA organization).</p>
                </div>
                <div className={selectedTab === 'payment-tab2' ? 'payment-tab-content' : 'payment-tab-content hidden'} id="payment-tab2">
                    {/* Nội dung cho tab 2 */}
                    <h1>Momo Wallet</h1>
                    <div className="payment2">
                        <div className="payment2-content">
                            <img className="imgpt2" src="https://www.cathaylife.com.vn/cathay/img/service/momo.png" alt="Momo" />
                            <div className="payment2-text">
                                <h2>Fee payment method</h2>
                                <p>
                                    <br />
                                    1. Log in to the application =&gt; Select “Insurance” =&gt; Select “Cathay Life Insurance”.
                                    <br /><br />
                                    2. Enter Contract number =&gt; Click “Continue”
                                    <br /><br />
                                    3. Check “Contract information” =&gt; Select “Type of fee to be paid” =&gt; Click “Continue”.
                                    <br /><br />
                                    4. Select Payment source (MoMo Wallet/Linked bank account/Other funds) =&gt; Check "Transaction details" =&gt; Click "Confirm".
                                    <br /><br />
                                    5. Confirm “Successful transaction”.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div className={selectedTab === 'payment-tab3' ? 'payment-tab-content' : 'payment-tab-content hidden'} id="payment-tab3">
                    {/* Nội dung cho tab 3 */}
                    <div className="payment3">
                        <h1>Pay at our partner bank</h1>
                        <p>You provide Cathay's policy number to the staff of any branch or transaction office of Sacombank, ACB, IVB to pay the insurance premium without having to pay any additional service fees.
                            <br /><br />
                            Look up the list of branches nationwide:
                            <br /><br />
                            <div className="listbanks">
                                <div className="banks">
                                    <img src="https://www.sacombank.com.vn/content/dam/sacombank/images/lien-he/sacombank-logo.svg" alt="" />
                                    <p>Saigon Thuong Tin Comercial Bank</p>
                                </div>
                                <div className="banks">
                                    <img src="https://www.acb.com.vn/_next/image?url=%2Fimages%2Flogo.svg&w=256&q=70" alt="" />
                                    <p>Asia Commercial Joint Stock Bank</p>
                                </div>
                                <div className="banks">
                                    <img src="https://www.indovinabank.com.vn/sites/default/files/ivb_logo_color.svg" alt="" />
                                    <p>IVB Bank</p>
                                </div>
                            </div>
                        </p>
                    </div>
                </div>
                <div className={selectedTab === 'payment-tab4' ? 'payment-tab-content' : 'payment-tab-content hidden'} id="payment-tab4">
                    {/* Nội dung cho tab 4 */}
                    <h2>Collect fees at home:</h2>
                    <p>For your absolute convenience, our fee collection staff or your consultant can come to collect fees at home if required.</p>
                    <div className="row">
                        <div className="row-content">
                            <h1>Pay fees directly at our Customer Service Center</h1>
                            <p>You can come to our Customer Service Centers to pay insurance premiums. After paying the premium, you will receive an insurance premium receipt from our Customer Service Center staff.</p>
                            <br />
                            <h3>Operating hours</h3>
                            <p>: Monday - Friday: 8:30 a.m. to 5:30 p.m</p>
                        </div>
                        <div className="row-content">
                            <div className="address">
                                <p>Addresses of We Customer Service Centers</p>
                                <p>Area
                                    <select id="areaSelect" onChange={handleAreaChange} value={selectedId}>
                                        <option value="hcm">Ho Chi Minh City</option>
                                        <option value="hn">Ha Noi</option>
                                        <option value="dn">Da Nang</option>
                                        <option value="hp">Hai Phong</option>
                                        <option value="ct">Can Tho</option>
                                        <option value="dnai">Dong Nai</option>
                                    </select>
                                </p>
                            </div>
                            <div className="content-select">
                                <div className={selectedId === 'hcm' ? 'contentsl active' : 'contentsl'} id="hcm">
                                    <ul>
                                        {selectedId === 'hcm' && (
                                            <>
                                                <li>5th Floor, VINA Building, 131 Xo Viet Nghe Tinh, Ward 17, Binh Thanh District, Ho Chi Minh City</li>
                                                <li>Tel: (84-28) 6255 6389 - Fax: (84-28) 6255 6388</li>
                                                <li>2nd Floor, Tan Da Court Building, 86 Tan Da, Ward 11, District 5, Ho Chi Minh City</li>
                                                <li>Tel: (84-28) 73050879</li>
                                            </>
                                        )}
                                    </ul>
                                </div>
                                <div className={selectedId === 'hn' ? 'contentsl active' : 'contentsl'} id="hn">
                                    <ul>
                                        {selectedId === 'hn' && (
                                            <>
                                                <li>167 Bui Thi Xuan, Hai Ba Trung District, Hanoi City</li>
                                                <li>Tel: (84-24) 6278 7888 - Fax: (84-24) 6278 7887</li>
                                            </>
                                        )}
                                    </ul>
                                </div>
                                <div className={selectedId === 'dn' ? 'contentsl active' : 'contentsl'} id="dn">
                                    <ul>
                                        {selectedId === 'dn' && (
                                            <>
                                                <li>6th Floor, Sacombank Building, 130-132 Bach Dang, Hai Chau District, Da Nang City</li>
                                                <li>Tel: (84-236) 625 2888 - Fax: (84-236) 625 3288</li>
                                            </>
                                        )}
                                    </ul>
                                </div>
                                <div className={selectedId === 'hp' ? 'contentsl active' : 'contentsl'} id="hp">
                                    <ul>
                                        {selectedId === 'hp' && (
                                            <>
                                                <li>8th floor, MobiFone Hai Phong telecommunications operations building, Anh Dung ward, Duong Kinh district, Hai Phong city</li>
                                                <li>Tel: (84-2253) 6255160 - Fax: (84-31) 6293622</li>
                                                <li>4th Floor, Sacombank Building, 62-64 Ton Duc Thang, Le Chan District, Hai Phong City</li>
                                                <li>Tel: (84-225) 6255160</li>
                                            </>
                                        )}
                                    </ul>
                                </div>
                                <div className={selectedId === 'ct' ? 'contentsl active' : 'contentsl'} id="ct">
                                    <ul>
                                        {selectedId === 'ct' && (
                                            <>
                                                <li>6th Floor, STS Building, 11B Hoa Binh, Tan An Ward, Ninh Kieu District, Can Tho City</li>
                                                <li>Tel: (84-292) 625 1999 - Fax: (84-292) 620 0160</li>
                                            </>
                                        )}
                                    </ul>
                                </div>
                                <div className={selectedId === 'dnai' ? 'contentsl active' : 'contentsl'} id="dnai">
                                    <ul>
                                        {selectedId === 'dnai' && (
                                            <>
                                                <li>9th Floor, Mira Central Park Building, 128/16 Nguyen Ai Quoc, Tan Tien Ward, Bien Hoa City, Dong Nai Province</li>
                                                <li>Tel: (84-251) 629 3558 - Fax: (84-251) 629 2575</li>
                                            </>
                                        )}
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div className={selectedTab === 'payment-tab5' ? 'payment-tab-content' : 'payment-tab-content hidden'} id="payment-tab5">
                    {/* Nội dung cho tab 5 */}
                    <h1>Via VNPost's post office</h1>
                    <p>Link to list of post offices: <a href="http://www.vnpost.vn/vi-vn/buu-cuc/tim-kiem/province/66/district/136/service/">http://www.vnpost.vn/vi-vn/buu-cuc/tim-kiem/province/66/district/136/service/</a>
                    </p>
                </div>
                <div className={selectedTab === 'payment-tab6' ? 'payment-tab-content' : 'payment-tab-content hidden'} id="payment-tab6">
                    {/* Nội dung cho tab 6 */}
                    <h1>Via Payoo</h1>
                    <p>Link to list of stores: <a href="https://payoo.vn/diem-giao-dich">Transaction point (payoo.vn)</a>
                    </p>
                </div>

            </div>
            <div className="bgr-servicepay">
                <div className="service-pay">
                    <div className="attention">
                        <h4>Important notes when paying insurance premiums</h4>
                        <ul>
                            <li>
                                <p>When paying insurance premiums to any of our representatives, please request a valid
                                    Receipt for the
                                    premium paid.</p>
                            </li>
                            <li>
                                <p>Within 03 working days, if you do not receive our message/email confirming fee payment,
                                    please
                                    contact us immediately via phone number 028 - 6255 6393. For payment method online, We only
                                    apply
                                    for insurance premium payment (including First Insurance Premium and Periodic Insurance
                                    Premium).</p>
                            </li>
                            <li>
                                <p>Therefore, for payments that do not comply with this regulation, we will refund the amount
                                    received
                                    according to the method you paid after deducting the bank fees incurred (if any).
                                </p>
                            </li>
                            <li>
                                <p>Adjustments that change the premium may result in an adjustment or cancellation of the issued
                                    invoice. We will notify you of the new invoice issued to replace the issued invoice (if
                                    any).
                                </p>
                            </li>
                        </ul>
                    </div>
                    <div className="imgsvp">
                        <img src="https://www.cathaylife.com.vn/cathay/img/service/img7.jpg" alt="Service Pay" />
                    </div>
                </div>
            </div>
        </div>
    );
}

export default PaymentDetails;
